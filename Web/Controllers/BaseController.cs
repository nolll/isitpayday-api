using System.Web.Http;
using System.Web.Mvc;
using Web.Cookies;
using Web.Plumbing;

namespace Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly Bootstrapper _bootstrapper;
        protected UseCaseContainer UseCase => _bootstrapper.UseCases;
        protected static bool IsInProduction => !WebContext.Host.EndsWith("lan");
        protected static int? PayDay => CookieContainer.PayDay;
        protected static string CountryCode => CookieContainer.CountryCode;
        protected static int? Frequency => CookieContainer.Frequency;
        protected static string TimezoneId => CookieContainer.TimezoneId;

        protected BaseController()
        {
            _bootstrapper = new Bootstrapper();
        }
    }

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