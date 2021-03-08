using System.Windows;
using TemplateWPF.ViewModel;

namespace TemplateWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewMode VModel;
        public MainWindow()
        {
            InitializeComponent();
            VModel = new MainWindowViewMode();
            this.DataContext = VModel;
        }
    }
}
