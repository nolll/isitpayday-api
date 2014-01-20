using System.Web.Mvc;
using Web.Commands;
using Web.Models;
using Web.PageBuilders;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageBuilder _pageBuilder;
        private readonly ICommandProvider _commandProvider;

        public HomeController(
            IPageBuilder pageBuilder,
            ICommandProvider commandProvider)
        {
            _pageBuilder = pageBuilder;
            _commandProvider = commandProvider;
        }

        public ActionResult Index(string change)
        {
            var pageModel = _pageBuilder.Build(change);
            return View(pageModel);
        }

        [HttpPost]
        public ActionResult Index(string change, IndexPagePostModel postModel)
        {
            var command = _commandProvider.GetSaveSettingsCommand(postModel);
            command.Execute();
            return RedirectToAction("Index");
        }

    }
}
