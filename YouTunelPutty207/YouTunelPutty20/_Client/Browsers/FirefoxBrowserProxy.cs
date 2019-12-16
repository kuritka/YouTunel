using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

namespace YouTunelPutty20._Client.Browsers
{
    internal class FirefoxBrowserProxy : IBrowserProxy
    {
        private const string ServerKey = "user_pref(\"network.proxy.http\", \"";
        private const string PortKey = "user_pref(\"network.proxy.http_port\", ";
        private const string ProxyTypeKey = "user_pref(\"network.proxy.type\", ";
        private const string PreferencesFileName = "prefs.js";

        private const string ShareNetworkProxySettings = "user_pref(\"network.proxy.share_proxy_settings\", ";


        //http://kb.mozillazine.org/Network.proxy.type
        private const int ManualProxyType = 1;
        private const int UseSystemProxyType = 5;


        //user_pref("network.proxy.share_proxy_settings", true);
        
        public BrowserProxySettings GetBrowserProxy()
        {
            var data = new BrowserProxySettings();
            try
            {
                var files = GetProfileFiles();
                foreach (var profilePath in files)
                {
                    int portNum;
                    int proxyType;
                    var text = File.ReadAllText(string.Format("{0}\\{1}", profilePath, PreferencesFileName));
                    data.Address = text.FindValue(ServerKey, "\");");
                    if (Int32.TryParse(text.FindValue(PortKey, ");"), out portNum))
                    {
                        data.Port = portNum;
                    }
                    data.SelectedProxySettings = 
                        Int32.TryParse(text.FindValue(ProxyTypeKey, ");"), out proxyType) ? 
                        proxyType : UseSystemProxyType;
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetBrowserSettings(BrowserProxySettings proxySettings)
        {
            try
            {
                TryUnlockSelectedProxySettings();
                var files = GetProfileFiles();
                foreach (var profilePath in files)
                {
                    var filePath = string.Format("{0}\\{1}", profilePath, PreferencesFileName);
                    var content = File.ReadAllText(filePath);
                    content = content.SetValue(proxySettings.Address, ServerKey, "\");");
                    
                    content = content.SetValue(string.Format("{0}", proxySettings.Port), PortKey, ");");
                    content = content.SetValue(string.Format("{0}", proxySettings.SelectedProxySettings), ProxyTypeKey, ");");
                    
                    //TODO: backup this value
                    content = content.SetValue("true", ShareNetworkProxySettings, ");");
                    //TODO: backup following values
                    content = content.SetValue(string.Format("{0}", proxySettings.Address), "user_pref(\"network.proxy.ftp\", \"", "\");");
                    content = content.SetValue(string.Format("{0}", proxySettings.Port), "user_pref(\"network.proxy.ftp_port\", ", ");");
                    content = content.SetValue(string.Format("{0}", proxySettings.Address), "user_pref(\"network.proxy.socks\", \"", "\");");
                    content = content.SetValue(string.Format("{0}", proxySettings.Port), "user_pref(\"network.proxy.socks_port\", ", ");");
                    content = content.SetValue(string.Format("{0}", proxySettings.Address), "user_pref(\"network.proxy.ssl\", \"", "\");");
                    content = content.SetValue(string.Format("{0}", proxySettings.Port), "user_pref(\"network.proxy.ssl_port\", ", ");");

                    
                    foreach (var process in System.Diagnostics.Process.GetProcessesByName("firefox"))
                    {
                        process.Kill();
                    }

                    File.Delete(filePath);
                    
                    File.WriteAllText(filePath, content);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //TODO: return to original state
        private void TryUnlockSelectedProxySettings()
        {
            var isModified = false;
            try
            {
                //https://msdn.microsoft.com/en-us/library/system.environment.is64bitoperatingsystem(VS.100).aspx
                var mozillaConfigPath =
                    Environment.Is64BitOperatingSystem
                        ? @"C:\Program Files (x86)\Mozilla Firefox\mozilla.cfg"
                        : @"C:\Program Files\Mozilla Firefox\mozilla.cfg";
                var configFile = new FileInfo(mozillaConfigPath);
                if (configFile.Exists)
                {
                    var lines = File.ReadAllLines(mozillaConfigPath);
                    var updatedLines = new List<string>();
                    foreach (var line in lines)
                    {
                        var replacedLine = line.Replace(" ", string.Empty);
                        if (!replacedLine.Contains("//lockPref(") && replacedLine.Contains("lockPref("))
                        {
                            //comment all locks like lockPref("network.proxy.type", 5);
                            updatedLines.Add(line.Replace(line, string.Format("//{0}", line)));
                            isModified = true;
                            continue;
                        }
                        updatedLines.Add(line);
                    }
                    if (isModified)
                    {
                        File.Delete(mozillaConfigPath);
                        File.WriteAllLines(mozillaConfigPath, updatedLines);
                    }
                }
            }
                //if(there are permission issues, I don't want to let application fail)
            catch
            {
                // write error message in log
            }
        }


        private IEnumerable<string> GetProfileFiles()
        {
            var data = ReadRegistryKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Folders",
                "AppData");
            var files = Directory.GetDirectories(string.Format("{0}\\Mozilla\\Firefox\\Profiles", data));
            return new List<string>(files);
        }


        private static string ReadRegistryKey(string subKey, string keyName)
        {
            try
            {
                var key = Registry.CurrentUser.OpenSubKey(subKey, true);
                if (key != null)
                {
                    return ((string)key.GetValue(keyName, keyName));
                }
            }
            catch
            {
                return "fault";
            }
            return string.Empty;
        }
    }



    internal static class StringHelper
    {
        public static string FindValue(this string text, string prefixPattern, string suffixPattern)
        {
            if (!text.Contains(prefixPattern)) return string.Empty;
            var str = text.Remove(0, text.IndexOf(prefixPattern, StringComparison.Ordinal) + prefixPattern.Length);
            return str.Substring(0, str.IndexOf(suffixPattern, StringComparison.Ordinal));
        }

        public static string SetValue(this string text, string value, string prefixPattern, string suffixPattern)
        {
            if (!text.Contains(prefixPattern))
            {
                text += prefixPattern + value + suffixPattern + "\r\n"; 
                return text;
            }
            var currentValue = FindValue(text, prefixPattern, suffixPattern);
            var startIndex = text.IndexOf(prefixPattern, StringComparison.Ordinal) + prefixPattern.Length;
            var newText = text.Remove(startIndex, currentValue.Length);
            return newText.Insert(startIndex, value);
        }
    }
}