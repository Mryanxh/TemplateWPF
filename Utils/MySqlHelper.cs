using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Text;

namespace TemplateWPF.Utils
{
    public class MySqlHelper
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static MySqlConnection mysql;
        public MySqlConnection Mysql
        {
            get
            {
                if (mysql == null)
                {
                    mysql = InitMysql();
                }
                return mysql;
            }
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter command = new MySqlDataAdapter(sql, Mysql);
                command.Fill(dt);
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("执行查询脚本出错:{0},脚本:{1}", ex.Message, sql);
            }
            return dt;
        }
        public int ExecuteSql(string sql)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, Mysql);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("执行更新脚本出错:{0},脚本:{1}", ex.Message, sql);
            }
            return 0;
        }
        private MySqlConnection InitMysql()
        {
            try
            {
                mysql = new MySqlConnection(GetConStr().ToString());
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("初始化数据库连接出错:{0}", ex.Message);
            }
            return mysql;
        }

        public bool CheckDBConnect()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(GetConStr().ToString());
                con.Open();
                Logger.Info("数据库连接成功!");
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("数据库连接失败:{0}", ex.Message);
                return false;
            }
        }
        public bool CheckDBConnect(string ip,uint port,string username,string password,string dbname)
        {
            string constr = new MySqlConnectionStringBuilder
            {
                Server = ip,
                Port = port,
                UserID = username,
                Password = password,
                Database = dbname,
                CharacterSet = Encoding.UTF8.WebName
            }.ToString();
            try
            {
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                Logger.Info("数据库连接成功!");
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("数据库连接失败:{0}", ex.Message);
                return false;
            }
        }

        private MySqlConnectionStringBuilder GetConStr()
        {
            return new MySqlConnectionStringBuilder
            {
                Server = Properties.Settings.Default.MySqlIpAddress,
                Port = Properties.Settings.Default.MySqlPort,
                UserID = Properties.Settings.Default.MySqlUserName,
                Password = Properties.Settings.Default.MySqlPassword,
                Database = Properties.Settings.Default.MySqlDBName,
                CharacterSet = Encoding.UTF8.WebName
            };
        }
    }
}
