using System;
using System.Web.Http;
using Core.UseCases;
using Web.Models;

namespace Web.Controllers
{
    public class MonthlyController : BaseApiController
    {
        [HttpGet]
        public PayDayModel Index(int payday, string country, string timezone)
        {
            var payDayRequest = new MonthlyPayday.Request(payday, country, timezone, DateTime.UtcNow);
            var showPayDayResult = UseCase.MonthlyPayday.Execute(payDayRequest);

            return new PayDayModel(showPayDayResult);
        }
    }
}