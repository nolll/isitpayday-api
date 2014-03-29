using Castle.Core;
using Castle.Windsor;
using Core.DateEvaluators;
using Core.Services;
using Core.Storage;
using Core.UseCases;
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
            // Repositories
            RegisterComponent<IUserSettingsService, UserSettingsService>();

            // Services
            RegisterComponent<ICountryService, CountryService>();
            RegisterComponent<IPayDayService, PayDayService>();
            RegisterComponent<ITimeService, TimeService>();
            
            // Interactors
            RegisterComponent<IShowPayDay, ShowPayDay>();
            RegisterComponent<ISaveSettings, SaveSettings>();

            // Misc
            RegisterComponent<IStorage, CookieStorage>();
            RegisterComponent<IWebContext, WebContext>();
            RegisterComponent<ICommandProvider, CommandProvider>();
            RegisterComponent<IPayDayEvaluator, PayDayEvaluator>();
            RegisterComponent<IBlockedEvaluator, BlockedEvaluator>();
            RegisterComponent<IWeekendEvaluator, WeekendEvaluator>();
            RegisterComponent<IExcludedEvaluator, ExcludedEvaluator>();
   
            // Page Builders
            RegisterComponent<IPageBuilder, PageBuilder>();
            
            // Model Factories
            RegisterComponent<IGoogleAnalyticsModelFactory, GoogleAnalyticsModelFactory>();
            RegisterComponent<ISettingsFormModelFactory, SettingsFormModelFactory>();
        }
    }
}