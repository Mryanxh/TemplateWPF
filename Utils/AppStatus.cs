/* ===============================================
* 功能描述：AppStatus  
* 创 建 人：阿拉丁等等等灯
* 创建日期：2021/2/2 14:56:27
* CLR版本：4.0.30319.42000
* 机器名称：YANXH-PC
* 用户所在域：YANXH-PC
* 注册组织名：
* 命名空间名称：TemplateWPF.Utils
* 当前登录用户名：mryan
* ================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TemplateWPF.Utils
{
    public class AppStatus
    {
        private static Assembly Assembly { get { return Assembly.GetExecutingAssembly(); } }
        /// <summary>
        /// 当前程序版本
        /// </summary>
        public static Version AppVersion { get { return Assembly.GetName().Version; } }
        /// <summary>
        /// 当前程序名称
        /// </summary>
        public static string AppName { get { return Assembly.GetName().Name; } }
    }
}
