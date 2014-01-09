using System.Web.Mvc;
using Web.PageBuilders;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageBuilder _pageBuilder;

        public HomeController(IPageBuilder pageBuilder)
        {
            _pageBuilder = pageBuilder;
        }

        public ActionResult Index(string change = null)
        {
            var pageModel = _pageBuilder.Build(change);
            return View(pageModel);
        }

    }
}
