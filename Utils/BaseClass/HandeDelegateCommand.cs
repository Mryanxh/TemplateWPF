/* ===============================================
* 功能描述：HandeDelegateCommand  
* 创 建 人：燕晓贺
* 创建日期：2021/2/2 15:15:53
* CLR版本：4.0.30319.42000
* 机器名称：YANXH-PC
* 用户所在域：YANXH-PC
* 注册组织名：
* 命名空间名称：TemplateWPF.Utils.BaseClass
* 当前登录用户名：mryan
* ================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TemplateWPF.Utils.BaseClass
{
    public class HandeDelegateCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteFunc == null)
            {
                return true;
            }

            return this.CanExecuteFunc(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (this.ExecuteAction == null)
            {
                return;
            }
            this.ExecuteAction(parameter);
        }

        private Action<object> ExecuteAction { get; set; }
        public Func<object, bool> CanExecuteFunc { get; set; }

        public HandeDelegateCommand(Action<object> executeAction)
        {
            ExecuteAction = executeAction;
        }
    }
}
