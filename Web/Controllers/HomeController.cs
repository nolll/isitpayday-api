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
            var payDayRequest = new ShowPayDay.Request(PayDay, Frequency, CountryCode, TimezoneId, DateTime.UtcNow);
            var showPayDay = UseCase.ShowPayDay.Execute(payDayRequest);
            var settingsRequest = new ShowSettings.Request(PayDay, Frequency, CountryCode, TimezoneId);
            var showSettings = UseCase.ShowSettings.Execute(settingsRequest);
            var optionsResult = UseCase.Options.Execute();
            var pageModel = new IndexPageModel(showPayDay, IsInProduction, showSettings, optionsResult, change);
            return View("~/Views/Home/Index.cshtml", pageModel);
        }

        [HttpPost]
        public ActionResult Index(SettingsPostModel postModel)
        {
            var settingsRequest = new ShowSettings.Request(PayDay, Frequency, CountryCode, TimezoneId);
            var showSettings = UseCase.ShowSettings.Execute(settingsRequest);
            var saveSettingsRequest = new SaveSettings.Request(showSettings.Country.Id, postModel.CountryId, showSettings.TimeZone.Id, postModel.TimeZoneId, showSettings.PayDay, postModel.PayDay, (int)showSettings.Frequency, postModel.FrequencyId);
            UseCase.SaveSettings.Execute(saveSettingsRequest);
            return RedirectToAction("Index");
        }
    }
}
