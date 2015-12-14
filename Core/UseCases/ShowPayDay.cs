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
            var userSettings = new UserSettings(request.PayDay, request.PayDayType, request.CountryCode, request.TimezoneId);
            var userTime = TimeZoneInfo.ConvertTime(utcTime, userSettings.TimeZone);
            var evaluator = PayDayEvaluator.Create(userSettings.PayDayType, utcTime, userSettings.TimeZone, userSettings.PayDay);
            var isPayDay = evaluator.IsPayDay;
            return new Result(isPayDay, userTime);
        }

        public class Request
        {
            public int? PayDay { get; }
            public int? PayDayType { get; }
            public string CountryCode { get; }
            public string TimezoneId { get; }
            public DateTime UtcTime { get; }

            public Request(int? payDay, int? payDayType, string countryCode, string timezoneId, DateTime utcTime)
            {
                PayDay = payDay;
                PayDayType = payDayType;
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