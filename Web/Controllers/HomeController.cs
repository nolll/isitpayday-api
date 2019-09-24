using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        [Route(Routes.Home)]
        public ActionResult Index()
        {
            var pageModel = new PageModel(IsInProduction);
            return View("~/Views/Home/Index.cshtml", pageModel);
        }
    }
}
