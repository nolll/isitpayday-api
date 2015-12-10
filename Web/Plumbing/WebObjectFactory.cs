using Castle.Core;
using Castle.Windsor;
using Core.DateEvaluators;
using Core.Services;
using Core.Storage;

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

            // Misc
            RegisterComponent<IStorage, CookieStorage>();
            RegisterComponent<IPayDayEvaluator, PayDayEvaluator>();
            RegisterComponent<IBlockedEvaluator, BlockedEvaluator>();
            RegisterComponent<IWeekendEvaluator, WeekendEvaluator>();
            RegisterComponent<IExcludedEvaluator, ExcludedEvaluator>();
        }
    }
}