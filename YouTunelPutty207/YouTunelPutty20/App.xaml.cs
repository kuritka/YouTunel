using System.Windows;
using YouTunelPutty20.TaskbarNotification;
using YouTunelPutty20._Client.Model;

namespace YouTunelPutty20
{
    /// <summary>
    /// Simple application. Check the XAML for comments.
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon _notifyIcon;

        protected override void OnStartup(StartupEventArgs e)
        {            
            base.OnStartup(e);
            //create the notifyicon (it's a resource declared in NotifyIconResources.xaml
            _notifyIcon = (TaskbarIcon) FindResource("NotifyIcon");
            DispatcherUnhandledException += AppDispatcherUnhandledException;
        }

        void AppDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            ConnectionSingleton.Instance.Disconnect();            
            MessageBox.Show("Došlo k neočekávané chybě :-0","CHYBA!!");
            _notifyIcon.Dispose(); 
        }

        protected override void OnExit(ExitEventArgs e)
        {
            ConnectionSingleton.Instance.Disconnect();
            if(!_notifyIcon.IsDisposed)
                _notifyIcon.Dispose();          //the icon would clean up automatically, but this is cleaner
            base.OnExit(e);
        }

        

    }
}
