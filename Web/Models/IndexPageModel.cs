namespace Web.Models
{
    public class IndexPageModel : IPageModel
    {
        public string PayDayString { get; private set; }
        public string LocalTime { get; private set; }
        public SettingsFormModel SettingsFormModel { get; private set; }
        public GoogleAnalyticsModel GoogleAnalyticsModel { get; private set; }

        public IndexPageModel(
            string payDayString,
            string localTime,
            SettingsFormModel settingsFormModel,
            GoogleAnalyticsModel googleAnalyticsModel)
        {
            PayDayString = payDayString;
            LocalTime = localTime;
            SettingsFormModel = settingsFormModel;
            GoogleAnalyticsModel = googleAnalyticsModel;
        }
    }
}