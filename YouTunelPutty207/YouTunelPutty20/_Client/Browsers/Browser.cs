namespace YouTunelPutty20._Client.Browsers
{
    internal sealed class Browser
    {
        public Browser(IBrowserProxy browserProxy, BrowserProxySettings backupSettings, bool isInstalled)
        {
            BrowserProxy = browserProxy;
            BackupSettings = backupSettings;
            IsInstalled = isInstalled;
        }

        public Browser(IBrowserProxy browserProxy, bool isInstalled = true)
            : this(browserProxy,null,isInstalled){}


        public bool BackupExists {get { return BackupSettings != null; }}

        private BrowserProxySettings BackupSettings { get; set; }

        public IBrowserProxy BrowserProxy { get; set; }

        public  bool IsInstalled { get; set; }

        
        public  void Setup()
        {
            BackupSettings = BrowserProxy.GetBrowserProxy();
            BrowserProxy.SetBrowserSettings(new BrowserProxySettings(Constants.Localhost, Constants.LocalhostPort));
        }


        public void Revert()
        {
            BrowserProxy.SetBrowserSettings(new BrowserProxySettings(BackupSettings.Address, BackupSettings.Port, BackupSettings.SelectedProxySettings));
            BackupSettings = null;
        }

    }
}
