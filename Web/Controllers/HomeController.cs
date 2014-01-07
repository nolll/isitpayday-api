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

        public ActionResult Index()
        {
            var pageModel = _pageBuilder.Build();
            return View(pageModel);
        }

    }
}
