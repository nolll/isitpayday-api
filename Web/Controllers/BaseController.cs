using System.Web.Mvc;

namespace Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected bool IsInProduction => Host.Contains("isitpayday.com");
        private string Host => Request?.Url?.Host ?? "";
    }
}