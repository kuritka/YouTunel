using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using Renci.SshNet;
using YouTunelPutty20._Client.Extensions;

namespace YouTunelPutty20._Client.Model
{
    internal sealed partial class ConnectionSingleton
    {
        private Stream _keyStream;
        private SshClient _ssh;
        private MemoryStream _inStream;
        private MemoryStream _outStream;
        private ForwardedPortLocal _forwardedPort;
        private Shell _shell;
      
        private static ConnectionSingleton _instance;

        private bool _connected;

        private BrowserAccessor Browsers { get; set; }
        
        private ConnectionSingleton()
        {
            Browsers = new BrowserAccessor();
            SystemProxy = WebProxy.GetDefaultProxy();
        }

        public static ConnectionSingleton Instance
        {
            get { return _instance ?? (_instance = new ConnectionSingleton()); }
        }
        
        public void Disconnect()
        {         
            _connected = false;
            
            if (Browsers.Explorer.BackupExists)
            {
                Browsers.Explorer.Revert();  
            }

            if (Browsers.Firefox.BackupExists)
            {
                Browsers.Firefox.Revert();
            }

            if (_shell != null)
            {
                _shell.Stop();
            }

            if (_forwardedPort != null)
            {
                _forwardedPort.Stop();
            }

            if (_ssh != null)
            {
                _ssh.Disconnect();
            }

            _keyStream.CloseIfNotNull();

            _inStream.CloseIfNotNull();

            _outStream.CloseIfNotNull();            
        }

     

        public void Connect(ConnectionSettings connectionSettings)
        {
            try
            {
                //http://www.ragestorm.net/tutorial?id=15
                //https://greenbytes.de/tech/webdav/draft-ietf-httpbis-p7-auth-00.html
                _inStream = new MemoryStream();
                _outStream = new MemoryStream();

                var assembly = Assembly.GetExecutingAssembly();
                _keyStream = assembly.GetManifestResourceStream(Constants.PrivateKeyFileName);

                var methods = new List<AuthenticationMethod>
                {
                    new PasswordAuthenticationMethod(connectionSettings.User, connectionSettings.Password),
                    new PrivateKeyAuthenticationMethod(connectionSettings.User,
                        new PrivateKeyFile(_keyStream, connectionSettings.Password))
                };

                var connection = SystemProxy.Address == null
                    ? new ConnectionInfo(
                        connectionSettings.Host, connectionSettings.Port, connectionSettings.User, methods.ToArray())
                    : new ConnectionInfo(
                        connectionSettings.Host, connectionSettings.Port, connectionSettings.User, ProxyTypes.Http,
                        SystemProxy.Address.Host, SystemProxy.Address.Port, connectionSettings.DomainUser,
                        connectionSettings.DomainPassword, methods.ToArray());

                _ssh = new SshClient(connection);
                _ssh.ConnectionInfo.MaxSessions = _ssh.ConnectionInfo.MaxSessions * 3;
                _ssh.ConnectionInfo.RetryAttempts = _ssh.ConnectionInfo.RetryAttempts * 2;
                _ssh.ConnectionInfo.Timeout = new TimeSpan(0, 0, 40);
                _ssh.KeepAliveInterval = new TimeSpan(0, 0, 100);
                _ssh.ConnectionInfo.Timeout = new TimeSpan(0, 0, 100);
                _ssh.Connect();
                _forwardedPort = new ForwardedPortLocal(Constants.Localhost, 8082, connectionSettings.Host, 8081);
                _ssh.AddForwardedPort(_forwardedPort);
                _shell = _ssh.CreateShell(Encoding.UTF8, "", _inStream, _outStream);
                _forwardedPort.Start();
                _shell.Start();
                
                _connected = true;

                if (connectionSettings.SetExplorer)
                {
                    Browsers.Explorer.Setup();                   
                }
                if (connectionSettings.SetFirefox)
                {
                    Browsers.Firefox.Setup();                    
                }
            }
            catch (Exception)
            {
                DisposeResources();
                throw;
            }
            finally
            {
                connectionSettings.DomainPassword = string.Empty;
            }
        }


        private void DisposeResources()
        {
            _keyStream.CloseIfNotNull();
            _ssh.CloseIfNotNull();
            _forwardedPort.CloseIfNotNull();
            _inStream.CloseIfNotNull();
            _outStream.CloseIfNotNull();            
        }


     
        //http://msdn.microsoft.com/en-us/library/system.net.webproxy.usedefaultcredentials.aspx
        //http://msdn.microsoft.com/en-us/library/system.net.credentialcache.defaultcredentials.aspx
        public bool ProxyNeedsAuthentication
        {
            get
            {
                return !_connected  
                    && !SystemProxy.UseDefaultCredentials 
                    && (SystemProxy.Address != null);
            }
        }        
    }    
}
