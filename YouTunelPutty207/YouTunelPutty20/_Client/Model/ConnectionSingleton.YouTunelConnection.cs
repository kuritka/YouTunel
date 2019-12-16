using System.Collections.Generic;
using System.Net;

namespace YouTunelPutty20._Client.Model
{
    partial class ConnectionSingleton
    {
        
        public Dictionary<string, KeyValuePair<string, int>> HostList
        {
            get { return _hostListList; }
        }

        private WebProxy SystemProxy { get; set; }

        private readonly Dictionary<string, KeyValuePair<string, int>> _hostListList = new Dictionary<string, KeyValuePair<string, int>>
            {
                { "Frankfurt [:6666]", new KeyValuePair<string,int>("services.commerz-systems.com",6666)} ,
                { "Prague [:6666]", new KeyValuePair<string,int>("common.commerz-systems.com",6666)},
            };        
    }

}
