using System.Collections.Generic;
using YouTunelPutty20._Client.Model;

namespace YouTunelPutty20._Client.ViewModel
{
    partial class MainWindowViewModel
    {

        public bool SetupExplorer
        {
            get { return ApplicationStateSingleton.Instance.ApplicationState.SetupExplorer; }
            set
            {
                ApplicationStateSingleton.Instance.ApplicationState.SetupExplorer = value;
                NotifyOnPropertyChanged(() => SetupExplorer);
            }
        }
        
        public bool SetupFirefox
        {
            get { return ApplicationStateSingleton.Instance.ApplicationState.SetupFirefox; }
            set
            {
                ApplicationStateSingleton.Instance.ApplicationState.SetupFirefox = value;
                NotifyOnPropertyChanged(() => SetupFirefox);
            }
        }


        public KeyValuePair<string, int> SelectedProxy
        {
            get { return ApplicationStateSingleton.Instance.ApplicationState.SelectedProxy; }
            set
            {
                ApplicationStateSingleton.Instance.ApplicationState.SelectedProxy = value;
                NotifyOnPropertyChanged("SelectedProxy");
            }
        }


        public ConnectionState ConnectionState
        {
            get { return ApplicationStateSingleton.Instance.ApplicationState.Connected; }
            set
            {
                ApplicationStateSingleton.Instance.ApplicationState.Connected = value;
                NotifyOnPropertyChanged("ConnectionState");
            }
        }


        public string DomainUser
        {
            get { return ApplicationStateSingleton.Instance.ApplicationState.DomainUser; } 
            set { ApplicationStateSingleton.Instance.ApplicationState.DomainUser = value; }
        }
        
    }
}
