using Castle.Core;
using Castle.Windsor;
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
            RegisterComponent<IUserSettingsService, UserSettingsService>();
            RegisterComponent<IStorage, CookieStorage>();
        }
    }
}