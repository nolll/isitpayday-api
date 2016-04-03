using System;
using Core.Classes;
using Core.UseCases;
using Web.Models;

namespace Web.Controllers
{
    public class DataController : BaseApiController
    {
        public DataModel Get(string frequency, int payday, string country, string timezone)
        {
            var frequencyInt = GetFrequencyInt(frequency);
            var payDayRequest = new ShowPayDay.Request(payday, frequencyInt, country, timezone, DateTime.UtcNow);
            var showPayDayResult = UseCase.ShowPayDay.Execute(payDayRequest);

            return new DataModel(showPayDayResult);
        }

        private int GetFrequencyInt(string frequencyName)
        {
            if (frequencyName == "weekly")
                return (int) Frequency.Weekly;
            return (int) Frequency.Monthly;
        }
    }
}
