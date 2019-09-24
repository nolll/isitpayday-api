using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Settings;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        [Route(Routes.Home)]
        public ActionResult Index(AppSettings appSettings)
        {
            var pageModel = new PageModel(IsInProduction, appSettings);
            return View("~/Views/Home/Index.cshtml", pageModel);
        }
    }
}
