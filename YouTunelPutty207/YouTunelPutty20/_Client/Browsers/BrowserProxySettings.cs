namespace YouTunelPutty20._Client.Browsers
{
    internal class BrowserProxySettings
    {
        public BrowserProxySettings()
        {
            Address = string.Empty;
            Port = 0;
            SelectedProxySettings = -1;
        }

        public BrowserProxySettings(string address, int port, int  selectedProxySettings = 1)
        {
            Address = address;
            Port = port;
            SelectedProxySettings = selectedProxySettings;
        }

        public string Address { get; set; }
        public int Port { get; set; }
        public int SelectedProxySettings { get; set; }
        public bool BypassProxy { get; set; }
    }
}
