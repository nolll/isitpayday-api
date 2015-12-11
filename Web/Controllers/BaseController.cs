using System.Web.Mvc;
using Web.Plumbing;

namespace Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly Bootstrapper _bootstrapper;
        private readonly CookieContainer _cookies;

        protected BaseController()
        {
            _bootstrapper = new Bootstrapper();
            _cookies = new CookieContainer();
        }

        protected UseCaseContainer UseCase
        {
            get { return _bootstrapper.UseCases; }
        }

        protected bool IsInProduction
        {
            get { return !WebContext.Host.EndsWith("lan");; }
        }

        protected int? PayDay
        {
            get { return _cookies.PayDay; }
        }

        protected string CountryCode
        {
            get { return _cookies.CountryCode; }
        }

        protected int? PayDayType
        {
            get { return _cookies.PayDayType; }
        }

        protected string TimezoneId
        {
            get { return _cookies.TimezoneId; }
        }
    }
}