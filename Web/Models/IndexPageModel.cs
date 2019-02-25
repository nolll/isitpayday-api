namespace Web.Models
{
    public class IndexPageModel : IPageModel
    {
        public GoogleAnalyticsModel GoogleAnalyticsModel { get; }
        public string Version { get; }

        public IndexPageModel(bool isInProduction)
        {
            GoogleAnalyticsModel = new GoogleAnalyticsModel(isInProduction);
            Version = AppSettings.Version;
        }
    }
}