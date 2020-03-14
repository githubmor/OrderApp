using GalaSoft.MvvmLight.Messaging;
using Hardcodet.Wpf.TaskbarNotification;
using Microsoft.Win32;
using OrdersAndisheh.ViewModel;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace OrdersAndisheh.View
{
    /// <summary>
    /// Description for FirstView.
    /// </summary>
    public partial class FirstView : Window
    {
        //private TaskbarIcon tb;
        //private NotifyIcon TrayIcon;
        //private ContextMenuStrip TrayIconContextMenu;
        //private ToolStripMenuItem CloseMenuItem;
        /// <summary>
        /// Initializes a new instance of the FirstView class.
        /// </summary>
        public FirstView()
        {
            InitializeComponent();
        }


        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                this.Hide();

            base.OnStateChanged(e);
        }

       

        private void MaximaizeFirstView(object sender, RoutedEventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
        }

       
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}