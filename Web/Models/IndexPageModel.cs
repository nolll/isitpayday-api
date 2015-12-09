using Core.UseCases;

namespace Web.Models
{
    public class IndexPageModel : IPageModel
    {
        public string PayDayString { get; private set; }
        public string LocalTime { get; private set; }
        public SettingsFormModel SettingsFormModel { get; private set; }
        public GoogleAnalyticsModel GoogleAnalyticsModel { get; private set; }

        public IndexPageModel(ShowPayDay.Result showPayDayResult, bool isInProduction, ShowSettings.Result showSettingsResult, string activeForm)
        {
            PayDayString = showPayDayResult.Message;
            LocalTime = showPayDayResult.UserTime.ToString("R"); ;
            SettingsFormModel = new SettingsFormModel(showSettingsResult, activeForm);
            GoogleAnalyticsModel = new GoogleAnalyticsModel(isInProduction);
        }
    }
}