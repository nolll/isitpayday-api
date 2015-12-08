using Core.UseCases;
using Web.ModelFactories;
using Web.Models;

namespace Web.PageBuilders
{
    public class PageBuilder : IPageBuilder
    {
        private readonly IGoogleAnalyticsModelFactory _googleAnalyticsModelFactory;
        private readonly ISettingsFormModelFactory _settingsFormModelFactory;

        public PageBuilder(
            IGoogleAnalyticsModelFactory googleAnalyticsModelFactory,
            ISettingsFormModelFactory settingsFormModelFactory)
        {
            _googleAnalyticsModelFactory = googleAnalyticsModelFactory;
            _settingsFormModelFactory = settingsFormModelFactory;
        }

        public IndexPageModel Build(ShowPayDay.Result showPayDayResult, string activeForm = null)
        {
            var localTime = showPayDayResult.UserTime.ToString("R");
            var googleAnalyticsModel = _googleAnalyticsModelFactory.Create();
            var settingsFormModel = _settingsFormModelFactory.Create(activeForm);

            return new IndexPageModel(
                showPayDayResult.Message,
                localTime,
                settingsFormModel,
                googleAnalyticsModel);
        }
    }
}