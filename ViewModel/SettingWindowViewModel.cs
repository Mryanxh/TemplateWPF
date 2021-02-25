/* ===============================================
* 功能描述：SettingWindowViewModel  
* 创 建 人：燕晓贺
* 创建日期：2021/2/24 16:38:20
* CLR版本：4.0.30319.42000
* 机器名称：YANXH-PC
* 用户所在域：YANXH-PC
* 注册组织名：
* 命名空间名称：TemplateWPF.ViewModel
* 当前登录用户名：mryan
* ================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TemplateWPF.Utils.BaseClass;

namespace TemplateWPF.ViewModel
{
    public class SettingWindowViewModel: MyBindingBase
    {
        public string MysqlIPaddress
        {
            get { return Properties.Settings.Default.MySqlIpAddress; }
            set
            {
                Properties.Settings.Default.MySqlIpAddress = value;
                OnPropertyChanged("MysqlIPaddress");
            }
        }

        public uint Mysqlport
        {
            get { return Properties.Settings.Default.MySqlPort; }
            set
            {
                Properties.Settings.Default.MySqlPort = value;
                OnPropertyChanged("Mysqlport");
            }
        }

        public string Mysqlusername
        {
            get { return Properties.Settings.Default.MySqlUserName; }
            set
            {
                Properties.Settings.Default.MySqlUserName = value;
                OnPropertyChanged("Mysqlusername");
            }
        }

        public string MysqlDBname
        {
            get { return Properties.Settings.Default.MySqlDBName; }
            set
            {
                Properties.Settings.Default.MySqlDBName = value;
                OnPropertyChanged("MysqlDBname");
            }
        }

        public MyDelegateCommand CheckMysqlDBConnectCommand { get; set; }

        public MyDelegateCommand SaveSettingCommand { get; set; }
        public SettingWindowViewModel()
        {
            CheckMysqlDBConnectCommand = new MyDelegateCommand(CheckMysqlDBConnectCommandExe);
            SaveSettingCommand = new MyDelegateCommand(SaveSettingCommandExe);
        }

        private void CheckMysqlDBConnectCommandExe(object paramter)
        {
            string psw = GetPassword(paramter);
            try
            {
                if (StaticCache.MySqlUtil.CheckDBConnect(MysqlIPaddress, Mysqlport, Mysqlusername, psw, MysqlDBname))
                {
                    MessageBox.Show("数据库连接成功");
                }
                else
                {
                    MessageBox.Show("数据库连接失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SaveSettingCommandExe(object paramter)
        {
            string psw = GetPassword(paramter);
            Properties.Settings.Default.MySqlPassword = psw;
            Properties.Settings.Default.Save();
            MessageBox.Show("保存成功！");
        }

        private string GetPassword(object pswcontrol)
        {
            if (pswcontrol is PasswordBox pswcon)
            {
                return pswcon.Password;
            }
            return string.Empty;
        }
    }
}
