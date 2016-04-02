using System;
using Core.Classes;
using Core.UseCases;

namespace Web.Controllers
{
    public class DataController : BaseApiController
    {
        public DataModel Get()
        {
            const int payDay = 25;
            const int frequency = (int)Frequency.Monthly;
            const string countryCode = "SE";
            const string timezoneId = "W. Europe Standard Time";
            var payDayRequest = new ShowPayDay.Request(payDay, frequency, countryCode, timezoneId, DateTime.UtcNow);
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
