using Castle.Core;
using Castle.Windsor;
using Web.Controllers;
using Web.PageBuilders;
using Web.Services;
using Web.Storage;

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
        }

    }
}