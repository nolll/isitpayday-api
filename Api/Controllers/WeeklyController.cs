using System;
using Api.Models;
using Core.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class WeeklyController : BaseController
{
    [HttpGet]
    [Route(Routes.ApiWeekly)]
    public ActionResult Index(int payday, string country, string timezone)
    {
        var payDayRequest = new WeeklyPayday.Request(payday, country, timezone, DateTime.UtcNow);
        var showPayDayResult = UseCase.WeeklyPayday.Execute(payDayRequest);

        return Json(new PayDayModel(showPayDayResult));
    }
}