using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YouTunelPutty20._Client.Model;

namespace YouTunelPutty20._Client.ViewModel
{
    internal  sealed partial class MainWindowViewModel : MvvmBase
    {        
        public ICommand HideWindowCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CommandAction = () => Application.Current.MainWindow.Close(),
                    CanExecuteFunc = () => Application.Current.MainWindow != null
                };
            }
        }


        public ICommand ConnectCommand
        {
            get
            {
                return new DelegateParametrisedCommand

                {
                    CommandAction = param =>
                    {
                        switch (ConnectionState)
                        {
                            case ConnectionState.Connected:
                                Connect(GetPasswordFromPasswordBox(param));                                
                                break;
                            case ConnectionState.Connecting:
                            case ConnectionState.Disconnected:
                                Disconnect();                                
                                break;
                        }                        
                    } ,
                    CanExecuteFunc = param => true
                };   
            }
        }


        public ICommand HomeCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CanExecuteFunc = () => true,
                    CommandAction = () => OpenBrowserWindow()
                };
            }
        }


        private void OpenBrowserWindow()
        {
            var runExplorer = new System.Diagnostics.ProcessStartInfo();
            runExplorer.FileName = "explorer.exe";
            runExplorer.Arguments = @"http://youtunel.cz";
            System.Diagnostics.Process.Start(runExplorer); 
        }

        private void Connect(string userPassword)
        {        
            try
            {
                ConnectionState = ConnectionState.Connecting;      
                var settings = new ConnectionSettings(SelectedProxy.Key, SelectedProxy.Value,DomainUser,userPassword, SetupExplorer, SetupFirefox);
                ThreadPool.QueueUserWorkItem(OpenConnection, settings);
            }
            catch (Exception)
            {
                ConnectionState = ConnectionState.Disconnected;
                ShowError();
            }
        }

        
        private void Disconnect()
        {           
            ConnectionSingleton.Instance.Disconnect();
            ConnectionState = ConnectionState.Disconnected;
        }


        private string GetPasswordFromPasswordBox(object param)
        {
            var passwordBox = param as PasswordBox;
            return passwordBox != null ? passwordBox.Password : string.Empty;
        }


        private void OpenConnection(object state)
        {
            try
            {
                var settings = state as ConnectionSettings;
                if (state == null)
                    throw new NullReferenceException();
                ConnectionSingleton.Instance.Connect(settings);
                ConnectionState = ConnectionState.Connected;
            }
            catch (Exception)
            {
                ConnectionState = ConnectionState.Disconnected;
                ShowError();
            }            
        }


        private static void ShowError()
        {
            MessageBox.Show(
                "Server je nedostupný nebo během navazování spojení došlo k chybě. Zkuste vybrat jiný server a opakujte akci. Pokud máte spuštěných více než jednu instanci YouTunelPutty, zavřete je.",
                "CHYBA!!");
        }
    }
}
