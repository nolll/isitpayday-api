using Core.UseCases;

namespace Web.Models
{
    public class IndexPageModel : IPageModel
    {
        public string PayDayString { get; }
        public string LocalTime { get; }
        public SettingsFormModel SettingsFormModel { get; }
        public GoogleAnalyticsModel GoogleAnalyticsModel { get; }

        public IndexPageModel(ShowPayDay.Result showPayDayResult, bool isInProduction, ShowSettings.Result showSettingsResult, string activeForm)
        {
            PayDayString = showPayDayResult.Message;
            LocalTime = showPayDayResult.UserTime.ToString("R");
            SettingsFormModel = new SettingsFormModel(showSettingsResult, activeForm);
            GoogleAnalyticsModel = new GoogleAnalyticsModel(isInProduction);
        }
    }
}