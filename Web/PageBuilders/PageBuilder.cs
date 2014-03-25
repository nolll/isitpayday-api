using Core.Services;
using Core.UseCases.GetPayDay;
using Web.ModelFactories;
using Web.Models;

namespace Web.PageBuilders
{
    public class PageBuilder : IPageBuilder
    {
        private readonly ITimeService _timeService;
        private readonly IGoogleAnalyticsModelFactory _googleAnalyticsModelFactory;
        private readonly IUserSettingsService _userSettingsService;
        private readonly IShowPayDayInteractor _showPayDayInteractor;
        private readonly ISettingsFormModelFactory _settingsFormModelFactory;

        public PageBuilder(
            ITimeService timeService,
            IGoogleAnalyticsModelFactory googleAnalyticsModelFactory,
            IUserSettingsService userSettingsService,
            IShowPayDayInteractor showPayDayInteractor,
            ISettingsFormModelFactory settingsFormModelFactory)
        {
            _timeService = timeService;
            _googleAnalyticsModelFactory = googleAnalyticsModelFactory;
            _userSettingsService = userSettingsService;
            _showPayDayInteractor = showPayDayInteractor;
            _settingsFormModelFactory = settingsFormModelFactory;
        }

        public IndexPageModel Build(string activeForm)
        {
            var showPayDayResult = _showPayDayInteractor.Execute();
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