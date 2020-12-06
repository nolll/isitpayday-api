using Web.Settings;

namespace Web.Models
{
    public class PageModel
    {
        public GoogleAnalyticsModel GoogleAnalyticsModel { get; }
        public string Version { get; }

        public PageModel(bool isInProduction, AppSettings appSettings)
        {
            GoogleAnalyticsModel = new GoogleAnalyticsModel(isInProduction);
            Version = appSettings.Version;
        }
    }
}