using Castle.Core;
using Castle.Windsor;
using Core.DateEvaluators;
using Core.Services;
using Core.Storage;
using Core.UseCases;
using Infrastructure.Http.Storage;
using Web.Commands;
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
            
            // Use Cases
            RegisterComponent<ISaveSettings, SaveSettings>();
            RegisterComponent<IShowSettings, ShowSettings>();

            // Misc
            RegisterComponent<IStorage, CookieStorage>();
            RegisterComponent<IWebContext, WebContext>();
            RegisterComponent<ICommandProvider, CommandProvider>();
            RegisterComponent<IPayDayEvaluator, PayDayEvaluator>();
            RegisterComponent<IBlockedEvaluator, BlockedEvaluator>();
            RegisterComponent<IWeekendEvaluator, WeekendEvaluator>();
            RegisterComponent<IExcludedEvaluator, ExcludedEvaluator>();
        }
    }
}