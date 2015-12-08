using System.Web.Mvc;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly Bootstrapper _bootstrapper = new Bootstrapper();

        protected UseCaseContainer UseCase
        {
            get { return _bootstrapper.UseCases; }
        }
    }
}