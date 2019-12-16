using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace YouTunelPutty20._Client.Browsers
{
    internal sealed class ExplorerBrowserProxy : IBrowserProxy
    {
        [DllImport("wininet.dll")]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        private const int InternetOptionSettingsChanged = 39;
        private const int InternetOptionRefresh = 37;
       // private static bool settingsReturn, refreshReturn;


        public BrowserProxySettings GetBrowserProxy()
        {
            var browserProxy = new BrowserProxySettings();
            var registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            if (registry != null)
            {
                var proxyRecord  = registry.GetValue("ProxyServer");
                if (proxyRecord != null && !string.IsNullOrEmpty(proxyRecord.ToString()))
                {
                    var proxyParts = proxyRecord.ToString().Split(':');
                    browserProxy.Address = proxyParts[0];
                    if (proxyParts.Count() == 2)
                    {
                        int number;
                        if (Int32.TryParse(proxyParts[1], out number))
                        {
                            browserProxy.Port = number;
                        }
                    }
                }
                var proxyEnable = (int)registry.GetValue("ProxyEnable");
                browserProxy.SelectedProxySettings = proxyEnable;

                var bypassProxy = (string)registry.GetValue("ProxyOverride");
                browserProxy.BypassProxy = !string.IsNullOrEmpty(bypassProxy) && bypassProxy == "<local>";

            }            
            return browserProxy;
        }


        public void SetBrowserSettings(BrowserProxySettings proxySettings)
        {
            var registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            if (registry != null)
            {
                registry.SetValue("ProxyServer", string.Format("{0}:{1}", proxySettings.Address, proxySettings.Port));
                registry.SetValue("ProxyEnable", proxySettings.SelectedProxySettings);
                //todo:
                //http://stackoverflow.com/questions/1674119/what-key-in-windows-registry-disables-ie-connection-parameter-automatically-det
                //http://social.technet.microsoft.com/Forums/windowsserver/en-US/5a8a47fd-ab72-488c-bfad-d8c10d18b6be/ie-lan-settings-automatically-detect-settings?forum=winserverGP
            }

            if (proxySettings.BypassProxy)
            {
                registry.SetValue("ProxyOverride", "<local>");
            }
            else
            {
                registry.DeleteValue("ProxyOverride");
            }

            // These lines implement the Interface in the beginning of program 
            // They cause the OS to refresh the settings, causing IP to realy update
            //settingsReturn = InternetSetOption(IntPtr.Zero, InternetOptionSettingsChanged, IntPtr.Zero, 0);
            //refreshReturn = InternetSetOption(IntPtr.Zero, InternetOptionRefresh, IntPtr.Zero, 0);
        }


      

        public bool BrowserExists
        {
            get { return true; }
        }
    }
}
