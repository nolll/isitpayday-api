using System;
using System.Web.Http;
using Core.UseCases;
using Web.Models;

namespace Web.Controllers
{
    public class WeeklyController : BaseApiController
    {
        [HttpGet]
        public PayDayModel Index(int payday, string country, string timezone)
        {
            var payDayRequest = new WeeklyPayday.Request(payday, country, timezone, DateTime.UtcNow);
            var showPayDayResult = UseCase.WeeklyPayday.Execute(payDayRequest);

            return new PayDayModel(showPayDayResult);
        }
    }
}