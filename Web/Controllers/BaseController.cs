using System.Web.Mvc;
using Web.Plumbing;

namespace Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly Bootstrapper _bootstrapper;
        private readonly CookieContainer _cookies;
        protected UseCaseContainer UseCase => _bootstrapper.UseCases;
        protected bool IsInProduction => !WebContext.Host.EndsWith("lan");
        protected int? PayDay => _cookies.PayDay;
        protected string CountryCode => _cookies.CountryCode;
        protected int? PayDayType => _cookies.PayDayType;
        protected string TimezoneId => _cookies.TimezoneId;

        protected BaseController()
        {
            _bootstrapper = new Bootstrapper();
            _cookies = new CookieContainer();
        }
    }
}