using System;
using Core.UseCases;

namespace Web.Controllers
{
    public class DataController : BaseApiController
    {
        public DataModel Get(int frequency, int payday, string country, string timezone)
        {
            var payDayRequest = new ShowPayDay.Request(payday, frequency, country, timezone, DateTime.UtcNow);
            var showPayDayResult = UseCase.ShowPayDay.Execute(payDayRequest);

            return new DataModel(showPayDayResult);
        }
    }

    public class DataModel
    {
        public bool IsPayDay { get; }

        public DataModel(ShowPayDay.Result showPayDayResult)
        {
            IsPayDay = showPayDayResult.IsPayDay;
        }
    }
}
