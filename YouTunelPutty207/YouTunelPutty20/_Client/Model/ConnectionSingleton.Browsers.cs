using YouTunelPutty20._Client.Browsers;

namespace YouTunelPutty20._Client.Model
{
    partial class ConnectionSingleton
    {
        private class BrowserAccessor
        {
            public BrowserAccessor()
            {
                Explorer = new Browser(new ExplorerBrowserProxy());
                Firefox = new Browser(new FirefoxBrowserProxy());
            }

            public Browser Explorer { get; set; }

            public Browser Firefox { get; set; }
        }

    }
}
