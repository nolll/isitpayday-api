using Core.Services;
using Core.UseCases;
using Web.ModelFactories;
using Web.Models;

namespace Web.PageBuilders
{
    public class PageBuilder : IPageBuilder
    {
        private readonly ITimeService _timeService;
        private readonly IGoogleAnalyticsModelFactory _googleAnalyticsModelFactory;
        private readonly IUserSettingsService _userSettingsService;
        private readonly IShowPayDay _showPayDay;
        private readonly ISettingsFormModelFactory _settingsFormModelFactory;

        public PageBuilder(
            ITimeService timeService,
            IGoogleAnalyticsModelFactory googleAnalyticsModelFactory,
            IUserSettingsService userSettingsService,
            IShowPayDay showPayDay,
            ISettingsFormModelFactory settingsFormModelFactory)
        {
            _timeService = timeService;
            _googleAnalyticsModelFactory = googleAnalyticsModelFactory;
            _userSettingsService = userSettingsService;
            _showPayDay = showPayDay;
            _settingsFormModelFactory = settingsFormModelFactory;
        }

        public IndexPageModel Build(string activeForm)
        {
            var showPayDayResult = _showPayDay.Execute();
            var userSettings = _userSettingsService.GetSettings();
            var timeZone = userSettings.TimeZone;
            var usertime = _timeService.GetTime(timeZone);
            var localTime = usertime.ToString("R");
            var googleAnalyticsModel = _googleAnalyticsModelFactory.Create();
            var settingsFormModel = _settingsFormModelFactory.Create(userSettings, activeForm);

            return new IndexPageModel(
                    showPayDayResult.Message,
                    localTime,
                    settingsFormModel,
                    googleAnalyticsModel
                );
        }
    }
}