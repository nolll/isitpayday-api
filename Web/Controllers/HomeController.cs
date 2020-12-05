using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Services;
using Web.Settings;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly AppSettings _appSettings;
        private readonly INonceProvider _nonceProvider;

        public HomeController(AppSettings appSettings, INonceProvider nonceProvider)
        {
            _appSettings = appSettings;
            _nonceProvider = nonceProvider;
        }

        [HttpGet]
        [Route(Routes.Home)]
        public ActionResult Index()
        {
            var pageModel = new PageModel(IsInProduction, _appSettings, _nonceProvider);
            return View("~/Views/Home/Index.cshtml", pageModel);
        }
    }
}
