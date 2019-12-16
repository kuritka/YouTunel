namespace YouTunelPutty20._Client.Model
{
    internal class ConnectionSettings
    {
        public readonly string User;

        public readonly string Password;

        private ConnectionSettings(string host, int port, string domainUser, string domainPassword) 
        {
            Host = host;
            Port = port;
            DomainUser = domainUser;
            DomainPassword = domainPassword;
            User = Constants.YoutunelUser;
            Password = Constants.YoutunelPassword;
        }

        public ConnectionSettings(string host, int port, string domainUser, string domainPassword,bool setExplorer, bool setFirefox) 
            : this(host, port,domainUser,domainPassword)
        {
            SetExplorer = setExplorer;
            SetFirefox = setFirefox;
        }

        public string DomainUser { get; private set; }

        public string DomainPassword { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public bool SetExplorer { get; set; }

        public bool SetFirefox { get; set; }

    }
}
