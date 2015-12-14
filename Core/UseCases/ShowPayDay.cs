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
            var userTime = TimeZoneInfo.ConvertTime(utcTime, userSettings.TimeZone);
            var evaluator = PayDayEvaluator.Create(userSettings.Frequency, utcTime, userSettings.TimeZone, userSettings.PayDay);
            var isPayDay = evaluator.IsPayDay;
            return new Result(isPayDay, userTime);
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
            public DateTime UserTime { get; }

            public Result(bool isPayDay, DateTime userTime)
            {
                IsPayDay = isPayDay;
                UserTime = userTime;
            }
        }
    }
}