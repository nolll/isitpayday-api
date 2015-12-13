using System;
using System.Web.Mvc;
using Core.UseCases;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(string change)
        {
            var payDayRequest = new ShowPayDay.Request(PayDay, PayDayType, CountryCode, TimezoneId, DateTime.UtcNow);
            var showPayDay = UseCase.ShowPayDay.Execute(payDayRequest);
            var settingsRequest = new ShowSettings.Request(PayDay, PayDayType, CountryCode, TimezoneId);
            var showSettings = UseCase.ShowSettings.Execute(settingsRequest);
            var pageModel = new IndexPageModel(showPayDay, IsInProduction, showSettings, change);
            return View("~/Views/Home/Index.cshtml", pageModel);
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
