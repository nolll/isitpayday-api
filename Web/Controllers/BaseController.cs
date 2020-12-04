using Microsoft.AspNetCore.Mvc;
using Web.Plumbing;
using Environment = Web.Extensions.Environment;

namespace Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected bool IsInProduction => Environment.IsProd(Host);
        private string Host => Request?.Host.Host ?? "";
        private readonly Bootstrapper _bootstrapper;
        protected UseCaseContainer UseCase => _bootstrapper.UseCases;

        protected BaseController()
        {
            _bootstrapper = new Bootstrapper();
        }
    }
}