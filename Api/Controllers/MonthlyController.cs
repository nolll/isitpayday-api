using System;
using Api.Models;
using Core.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class MonthlyController : BaseController
{
    [HttpGet]
    [Route(Routes.ApiMonthly)]
    public ActionResult Index(int payday, string country, string timezone)
    {
        var payDayRequest = new MonthlyPayday.Request(payday, country, timezone, DateTime.UtcNow);
        var showPayDayResult = UseCase.MonthlyPayday.Execute(payDayRequest);

        return Json(new PayDayModel(showPayDayResult));
    }
}