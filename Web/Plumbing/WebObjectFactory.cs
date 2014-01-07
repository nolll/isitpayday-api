using Castle.Core;
using Castle.Windsor;
using Web.Controllers;

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
        }

    }
}