using System;
using Api.Models;
using Core.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class PaydayController : BaseController
{
    /// <summary>
    /// Get monthly payday.
    /// </summary>
    /// <param name="payday">Normal payday of the month. Default is 25.</param>
    /// <param name="country">Country (DK, NO, SE or US). Default is SE, Sweden.</param>
    /// <param name="timezone">Timezone. Default is Europe/Stockholm.</param>
    /// <returns>A boolean indicating if today is payday, and the date of the next payday.</returns>
    [HttpGet]
    [Route(Routes.ApiMonthly)]
    public ActionResult Monthly(int? payday, string country, string timezone)
    {
        var payDayRequest = new MonthlyPayday.Request(
            GetMonthlyPaydayParam(payday),
            GetCountryParam(country),
            GetTimezoneParam(timezone),
            DateTime.UtcNow);
        var showPayDayResult = UseCase.MonthlyPayday.Execute(payDayRequest);

        return Json(new PayDayModel(showPayDayResult));
    }

    /// <summary>
    /// Get weekly payday.
    /// </summary>
    /// <param name="payday">Normal payday of the week. Default is 5, friday.</param>
    /// <param name="country">Country (DK, NO, SE or US). Default is SE, Sweden.</param>
    /// <param name="timezone">Timezone. Default is Europe/Stockholm.</param>
    /// <returns>A boolean indicating if today is payday, and the date of the next payday.</returns>
    [HttpGet]
    [Route(Routes.ApiWeekly)]
    public ActionResult Weekly(int? payday, string country, string timezone)
    {
        var payDayRequest = new WeeklyPayday.Request(
            GetWeeklyPaydayParam(payday),
            GetCountryParam(country),
            GetTimezoneParam(timezone),
            DateTime.UtcNow);
        var showPayDayResult = UseCase.WeeklyPayday.Execute(payDayRequest);

        return Json(new PayDayModel(showPayDayResult));
    }

    [HttpGet]
    [Route(Routes.ApiMonthlyOld)]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult MonthlyOld(int? payday, string country, string timezone) => Monthly(payday, country, timezone);

    [HttpGet]
    [Route(Routes.ApiWeeklyOld)]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult WeeklyOld(int? payday, string country, string timezone) => Weekly(payday, country, timezone);

    private static int GetMonthlyPaydayParam(int? payday) => payday is null or < 1 or > 31
        ? 25
        : payday.Value;

    private static int GetWeeklyPaydayParam(int? payday) => payday is null or < 1 or > 7
        ? 5
        : payday.Value;

    private static string GetCountryParam(string country) => string.IsNullOrEmpty(country)
        ? "SE"
        : country.ToUpper();

    private static string GetTimezoneParam(string timezone) => string.IsNullOrEmpty(timezone)
        ? "Europe/Stockholm"
        : timezone;
}