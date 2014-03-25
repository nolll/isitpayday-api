namespace Web.Models
{
    public class IndexPageModel : IPageModel
    {
        public string PayDayString { get; set; }
        public string LocalTime { get; set; }
        public SettingsFormModel SettingsFormModel { get; set; }
        public GoogleAnalyticsModel GoogleAnalyticsModel { get; set; }

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