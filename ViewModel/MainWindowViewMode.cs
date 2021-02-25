/* ===============================================
* 功能描述：MainWindowViewMode  
* 创 建 人：阿拉丁等等等灯
* 创建日期：2021/2/2 15:21:23
* CLR版本：4.0.30319.42000
* 机器名称：YANXH-PC
* 用户所在域：YANXH-PC
* 注册组织名：
* 命名空间名称：TemplateWPF.ViewModel
* 当前登录用户名：mryan
* ================================================*/

using TemplateWPF.Model;
using TemplateWPF.Utils.BaseClass;
using TemplateWPF.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateWPF.ViewModel
{
    public class MainWindowViewMode: MyBindingBase
    {
        private readonly MainWindowModel _Model;
        public string MainTitle
        {
            get { return _Model.MainTitle; }
            set
            {
                _Model.MainTitle = value;
                OnPropertyChanged("MainTitle");
            }
        }

        public MyDelegateCommand CheckUpDataCommand { get; set; }
        public MyDelegateCommand ViewSettingCommand { get; set; }
        public MyDelegateCommand AbloutHelpCommand { get; set; }


        public MainWindowViewMode()
        {
            _Model = new MainWindowModel();
            ViewSettingCommand = new MyDelegateCommand(ViewSettingCommandExe);
            CheckUpDataCommand = new MyDelegateCommand(CheckUpDataCommandExe);
            AbloutHelpCommand = new MyDelegateCommand(AbloutHelpCommandExe);
        }

        private void ViewSettingCommandExe(object paramter)
        {
            int setIndex = 0;
            if (!string.IsNullOrEmpty(paramter.ToString()))
                int.TryParse(paramter.ToString(), out setIndex);
            new SettingWindow(setIndex).ShowDialog();
        }
        private void CheckUpDataCommandExe(object paramter)
        {

        }
        private void AbloutHelpCommandExe(object paramter)
        {
            new AbloutWindow().ShowDialog();
        }
    }
}
