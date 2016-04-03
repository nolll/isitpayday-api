using System;
using System.Web.Http;
using Core.Classes;
using Core.UseCases;
using Web.Models;

namespace Web.Controllers
{
    public class WeeklyController : BaseApiController
    {
        [HttpGet]
        public PayDayModel Index(int payday, string country, string timezone)
        {
            var payDayRequest = new ShowPayDay.Request(payday, (int)Frequency.Weekly, country, timezone, DateTime.UtcNow);
            var showPayDayResult = UseCase.ShowPayDay.Execute(payDayRequest);

            return new PayDayModel(showPayDayResult);
        }
    }
}