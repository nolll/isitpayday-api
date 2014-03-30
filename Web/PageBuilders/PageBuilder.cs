using Core.Services;
using Core.UseCases;
using Web.ModelFactories;
using Web.Models;

namespace Web.PageBuilders
{
    public class PageBuilder : IPageBuilder
    {
        private readonly IGoogleAnalyticsModelFactory _googleAnalyticsModelFactory;
        private readonly IShowPayDay _showPayDay;
        private readonly ISettingsFormModelFactory _settingsFormModelFactory;

        public PageBuilder(
            IGoogleAnalyticsModelFactory googleAnalyticsModelFactory,
            IShowPayDay showPayDay,
            ISettingsFormModelFactory settingsFormModelFactory)
        {
            _googleAnalyticsModelFactory = googleAnalyticsModelFactory;
            _showPayDay = showPayDay;
            _settingsFormModelFactory = settingsFormModelFactory;
        }

        public IndexPageModel Build(string activeForm)
        {
            var showPayDayResult = _showPayDay.Execute();
            var localTime = showPayDayResult.UserTime.ToString("R");
            var googleAnalyticsModel = _googleAnalyticsModelFactory.Create();
            var settingsFormModel = _settingsFormModelFactory.Create(activeForm);

            return new IndexPageModel(
                    showPayDayResult.Message,
                    localTime,
                    settingsFormModel,
                    googleAnalyticsModel
                );
        }
    }
}