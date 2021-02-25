using TemplateWPF.Utils;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace TemplateWPF
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 托盘图标
        /// </summary>
        private NotifyIcon trayIcon;
        /// <summary>
        /// 启动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            Logger.Info(string.Format("程序启动{0}", AppStatus.AppVersion.ToString()));
            InitNotifyIcon();
            this.trayIcon.ShowBalloonTip(30, "启动成功", string.Format("{0} v{1}", AppStatus.AppName, AppStatus.AppVersion.ToString()), ToolTipIcon.Info);
        }

        /// <summary>
        /// 结束时调用的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicationExit(object sender, ExitEventArgs e)
        {
            try
            {
                //程序退出时执行的任务

                Logger.Info("程序退出");
            }
            catch (Exception ex)
            {
                Logger.InfoFormat("错误退出:{0}",ex.Message);
            }
            Process.GetCurrentProcess().Kill();
        }
        
        /// <summary>
        /// 添加基础信息
        /// </summary>
        private void InitNotifyIcon()
        {
            if (trayIcon != null)
            {
                return;
            }
            trayIcon = new NotifyIcon
            {
                Visible = true,
                Text = string.Format("{0}", AppStatus.AppName),
                Icon = TemplateWPF.Properties.Resources.Logo
            };
            #region 添加右键菜单内容
            MenuItem ExitItem = new MenuItem();
            ExitItem.Text = "退出";
            ExitItem.Click += Exit_Click;
            MenuItem ViewWindow = new MenuItem();
            ViewWindow.Text = "显示主页面";
            ViewWindow.Click += ViewWindow_Click;
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add(ViewWindow);
            menu.MenuItems.Add(ExitItem);
            trayIcon.ContextMenu = menu;
            #endregion
        }

        private void ViewWindow_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, EventArgs e)
        {
            Logger.Info("手动退出");
            ApplicationExit(null, null);
        }
    }
}