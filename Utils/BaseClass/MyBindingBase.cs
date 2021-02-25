/* ===============================================
* 功能描述：MyBindingBase  
* 创 建 人：燕晓贺
* 创建日期：2021/2/2 15:14:09
* CLR版本：4.0.30319.42000
* 机器名称：YANXH-PC
* 用户所在域：YANXH-PC
* 注册组织名：
* 命名空间名称：TemplateWPF.Utils.BaseClass
* 当前登录用户名：mryan
* ================================================*/

using System.ComponentModel;

namespace TemplateWPF.Utils.BaseClass
{
    public class MyBindingBase:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string value)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(value));
        }
    }
}
