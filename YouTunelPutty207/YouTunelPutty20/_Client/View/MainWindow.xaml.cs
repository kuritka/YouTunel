using System;
using System.Windows;

namespace YouTunelPutty20._Client.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();                       
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width - 20;
            Top = desktopWorkingArea.Bottom - Height - 20;
            Topmost = true;                        
        }     
  
    }
}
