using System.Web.Mvc;
using Web.Plumbing;

namespace Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly Bootstrapper _bootstrapper;

        protected BaseController()
        {
            _bootstrapper = new Bootstrapper();
        }

        protected UseCaseContainer UseCase
        {
            get { return _bootstrapper.UseCases; }
        }

        protected bool IsInProduction
        {
            get { return !WebContext.Host.EndsWith("lan");; }
        }
    }
}