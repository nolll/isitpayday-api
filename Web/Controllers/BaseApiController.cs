using System.Web.Http;
using Web.Plumbing;

namespace Web.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private readonly Bootstrapper _bootstrapper;
        protected UseCaseContainer UseCase => _bootstrapper.UseCases;

        protected BaseApiController()
        {
            _bootstrapper = new Bootstrapper();
        }
    }
}