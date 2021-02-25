/* ===============================================
* 功能描述：StaticCache  
* 创 建 人：阿拉丁等等等灯
* 创建日期：2021/2/24 11:23:50
* CLR版本：4.0.30319.42000
* 机器名称：YANXH-PC
* 用户所在域：YANXH-PC
* 注册组织名：
* 命名空间名称：TemplateWPF
* 当前登录用户名：mryan
* ================================================*/

using TemplateWPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateWPF
{
    public class StaticCache
    {
        private static MySqlHelper _MySqlUtil;
        public static MySqlHelper MySqlUtil
        {
            get
            {
                if (_MySqlUtil is null)
                {
                    _MySqlUtil = new MySqlHelper();
                }
                return _MySqlUtil;
            }
        }
    }
}
