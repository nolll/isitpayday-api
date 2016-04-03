using System;
using Core.Classes;
using Core.DateEvaluators;

namespace Core.UseCases
{
    public class ShowPayDay
    {
        public Result Execute(Request request)
        {
            var utcTime = request.UtcTime;
            var userSettings = new UserSettings(request.PayDay, request.Frequency, request.CountryCode, request.TimezoneId);
            var evaluator = PayDayEvaluator.Create(userSettings.Frequency, userSettings.Country, utcTime, userSettings.TimeZone, userSettings.PayDay);
            var isPayDay = evaluator.IsPayDay;
            var localTime = TimeZoneInfo.ConvertTime(utcTime, userSettings.TimeZone);
            return new Result(isPayDay, localTime);
        }

        public class Request
        {
            public int? PayDay { get; }
            public int? Frequency { get; }
            public string CountryCode { get; }
            public string TimezoneId { get; }
            public DateTime UtcTime { get; }

            public Request(int? payDay, int? frequency, string countryCode, string timezoneId, DateTime utcTime)
            {
                PayDay = payDay;
                Frequency = frequency;
                CountryCode = countryCode;
                TimezoneId = timezoneId;
                UtcTime = utcTime;
            }
        }

        public class Result
        {
            public bool IsPayDay { get; }
            public DateTime LocalTime { get; }

            public Result(bool isPayDay, DateTime localTime)
            {
                IsPayDay = isPayDay;
                LocalTime = localTime;
            }
        }
    }
}