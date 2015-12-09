using System.Web.Mvc;

namespace Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly Bootstrapper _bootstrapper = new Bootstrapper();
        private readonly WebContext _webContext;

        protected BaseController()
        {
            _webContext = new WebContext(Request);
        }

        protected UseCaseContainer UseCase
        {
            get { return _bootstrapper.UseCases; }
        }

        protected bool IsInProduction
        {
            get { return _webContext.IsInProduction; }
        }
    }
}