namespace YouTunelPutty20._Client.Browsers
{
    interface IBrowserProxy
    {
        BrowserProxySettings  GetBrowserProxy();

        void SetBrowserSettings(BrowserProxySettings proxySettings);        
    }
}
