using System.Web.Mvc;
using Core.UseCases;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
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
            var saveSettingsRequest = new SaveSettingsRequest(postModel.CountryId, postModel.TimeZoneId, postModel.PayDay);
            UseCase.SaveSettings.Execute(saveSettingsRequest);
            return RedirectToAction("Index");
        }

    }
}
