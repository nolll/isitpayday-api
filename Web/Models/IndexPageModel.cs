namespace Web.Models
{
    public class IndexPageModel : IPageModel
    {
        public GoogleAnalyticsModel GoogleAnalyticsModel { get; }

        public IndexPageModel(bool isInProduction)
        {
            GoogleAnalyticsModel = new GoogleAnalyticsModel(isInProduction);
        }
    }
}