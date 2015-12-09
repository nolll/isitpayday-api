using Core.UseCases;
using Web.ModelFactories;
using Web.Models;

namespace Web.PageBuilders
{
    public class PageBuilder : IPageBuilder
    {
        private readonly ISettingsFormModelFactory _settingsFormModelFactory;

        public PageBuilder(
            ISettingsFormModelFactory settingsFormModelFactory)
        {
            _settingsFormModelFactory = settingsFormModelFactory;
        }

        public IndexPageModel Build(ShowPayDay.Result showPayDayResult, bool isInProduction, string activeForm = null)
        {
            var localTime = showPayDayResult.UserTime.ToString("R");
            var googleAnalyticsModel = new GoogleAnalyticsModel(isInProduction);
            var settingsFormModel = _settingsFormModelFactory.Create(activeForm);

            return new IndexPageModel(
                showPayDayResult.Message,
                localTime,
                settingsFormModel,
                googleAnalyticsModel);
        }
    }
}