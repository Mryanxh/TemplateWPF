﻿/* ===============================================
* 功能描述：MainWindowModel  
* 创 建 人：燕晓贺
* 创建日期：2021/2/2 15:23:57
* CLR版本：4.0.30319.42000
* 机器名称：YANXH-PC
* 用户所在域：YANXH-PC
* 注册组织名：
* 命名空间名称：TemplateWPF.Model
* 当前登录用户名：mryan
* ================================================*/

using TemplateWPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateWPF.Model
{
    public class MainWindowModel
    {
        public string MainTitle { get; set; }

        public MainWindowModel()
        {
            MainTitle = string.Format("{0}-{1}", AppStatus.AppName, AppStatus.AppVersion);
        }
    }
}
