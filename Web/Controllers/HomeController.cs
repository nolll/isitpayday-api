using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var pageModel = new IndexPageModel(IsInProduction);
            return View("~/Views/Home/Index.cshtml", pageModel);
        }
    }
}
