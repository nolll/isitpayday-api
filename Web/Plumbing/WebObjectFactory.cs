using Castle.Core;
using Castle.Windsor;
using Core.DateEvaluators;
using Core.Services;
using Core.Storage;
using Infrastructure.Http.Storage;
using Infrastructure.System.Services;
using Web.Commands;
using Web.Controllers;
using Web.ModelFactories;
using Web.PageBuilders;
using WebContext = Infrastructure.Http.Services.WebContext;

namespace Web.Plumbing
{
    public class WebObjectFactory : ObjectFactory
    {
        public WebObjectFactory(IWindsorContainer container, LifestyleType lifestyleType = LifestyleType.PerWebRequest)
            : base(container, lifestyleType)
        {
            RegisterTypes();
        }

        private void RegisterTypes()
        {
            RegisterComponent<IPageBuilder, PageBuilder>();
            RegisterComponent<IPayDayService, PayDayService>();
            RegisterComponent<IStorage, CookieStorage>();
            RegisterComponent<IWebContext, WebContext>();
            RegisterComponent<ITimeService, TimeService>();
            RegisterComponent<ICountryService, CountryService>();
            RegisterComponent<ICommandProvider, CommandProvider>();
            RegisterComponent<IGoogleAnalyticsModelFactory, GoogleAnalyticsModelFactory>();
            RegisterComponent<IPayDayEvaluator, PayDayEvaluator>();
            RegisterComponent<IBlockedEvaluator, BlockedEvaluator>();
            RegisterComponent<IWeekendEvaluator, WeekendEvaluator>();
            RegisterComponent<IExcludedEvaluator, ExcludedEvaluator>();
        }

    }
}