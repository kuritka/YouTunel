using System.Collections.Generic;
using System.Security.Principal;

namespace YouTunelPutty20._Client.Model
{
    internal sealed class ApplicationStateSingleton
    {        
           private static ApplicationStateSingleton _instance;

            private ApplicationStateSingleton()
            {
                ApplicationState = new ApplicationState();
                SetDomainUser();
            }

           public static ApplicationStateSingleton Instance
           {
              get 
              {
                 if (_instance == null)
                 {
                    _instance = new ApplicationStateSingleton();
                 }
                 return _instance;
              }
           }

            public ApplicationState ApplicationState { get; private set; }


            private void SetDomainUser()
            {
                var identity = WindowsIdentity.GetCurrent();
                if (identity != null)
                {
                    ApplicationState.DomainUser = identity.Name;
                }
            }
    }



    internal sealed class ApplicationState
    {
        public ConnectionState Connected { get; set; }
        public KeyValuePair<string, int> SelectedProxy { get; set; }
        public bool SetupFirefox { get; set; }
        public bool SetupExplorer { get; set; }
        public string DomainUser { get; set; }
    }

}
