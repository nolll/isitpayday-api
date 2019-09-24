using System.Configuration;

namespace Web
{
    public abstract class AppSettings
    {
        public static string Version => Get("Version");

        private static string Get(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }
    }
}