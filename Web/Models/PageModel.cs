using Web.Services;
using Web.Settings;

namespace Web.Models
{
    public class PageModel
    {
        public GoogleAnalyticsModel GoogleAnalyticsModel { get; }
        public string Version { get; }

        public PageModel(bool isInProduction, AppSettings appSettings, INonceProvider nonceProvider)
        {
            GoogleAnalyticsModel = new GoogleAnalyticsModel(isInProduction, nonceProvider);
            Version = appSettings.Version;
        }
    }
}