using Castle.Core;
using Castle.Windsor;
using Core.DateEvaluators;
using Core.Services;
using Core.Storage;
using Core.UseCases.GetPayDay;
using Core.UseCases.SaveSettings;
using Infrastructure.Http.Storage;
using Infrastructure.System.Services;
using Web.Commands;
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
            // Interactors
            RegisterComponent<IShowPayDayInteractor, ShowPayDayInteractor>();
            RegisterComponent<ISaveSettingsInteractor, SaveSettingsInteractor>();

            // Services
            RegisterComponent<ICountryService, CountryService>();
            RegisterComponent<IPayDayService, PayDayService>();
            RegisterComponent<ITimeService, TimeService>();
            
            // Repositories
            RegisterComponent<IUserSettingsService, UserSettingsService>();
            
            // Misc
            RegisterComponent<IPageBuilder, PageBuilder>();
            RegisterComponent<IStorage, CookieStorage>();
            RegisterComponent<IWebContext, WebContext>();
            RegisterComponent<ICommandProvider, CommandProvider>();
            RegisterComponent<IGoogleAnalyticsModelFactory, GoogleAnalyticsModelFactory>();
            RegisterComponent<IPayDayEvaluator, PayDayEvaluator>();
            RegisterComponent<IBlockedEvaluator, BlockedEvaluator>();
            RegisterComponent<IWeekendEvaluator, WeekendEvaluator>();
            RegisterComponent<IExcludedEvaluator, ExcludedEvaluator>();
            
        }

    }
}