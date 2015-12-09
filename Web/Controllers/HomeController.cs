using System.Web.Mvc;
using Web.Commands;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICommandProvider _commandProvider;

        public HomeController(ICommandProvider commandProvider)
        {
            _commandProvider = commandProvider;
        }

        public ActionResult Index(string change)
        {
            var showPayDay = UseCase.ShowPayDay.Execute();
            var showSettings = UseCase.ShowSettings.Execute();
            var pageModel = new IndexPageModel(showPayDay, IsInProduction, showSettings, change);
            return View(pageModel);
        }

        [HttpPost]
        public ActionResult Index(string change, SettingsPostModel postModel)
        {
            var command = _commandProvider.GetSaveSettingsCommand(postModel);
            command.Execute();
            return RedirectToAction("Index");
        }

    }
}
