using System.Web.Mvc;
using Web.Extensions;

namespace Web.Controllers
{
    [EnsureHttps]
    public abstract class BaseController : Controller
    {
        protected bool IsInProduction => Environment.IsProd(Host);
        private string Host => Request?.Url?.Host ?? "";
    }
}