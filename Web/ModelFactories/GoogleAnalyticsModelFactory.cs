using Core.Services;
using Web.Models;

namespace Web.ModelFactories
{
    public class GoogleAnalyticsModelFactory : IGoogleAnalyticsModelFactory
    {
        private readonly IWebContext _webContext;

        public GoogleAnalyticsModelFactory(IWebContext webContext)
        {
            _webContext = webContext;
        }

        public GoogleAnalyticsModel Create()
        {
            return new GoogleAnalyticsModel
                {
                    Enabled = _webContext.IsInProduction,
                    Code = "UA-8453410-4"
                };
        }
    }
}