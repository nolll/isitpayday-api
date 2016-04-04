using System;
using Core.Classes;
using Core.DateEvaluators;
using Core.UseCases.Shared;

namespace Core.UseCases
{
    public class WeeklyPayday
    {
        public PaydayResult Execute(Request request)
        {
            var utcTime = request.UtcTime;
            var userSettings = new UserSettings(request.PayDay, request.CountryCode, request.TimezoneId);
            var evaluator = new WeeklyPayDayEvaluator(userSettings.Country, utcTime, userSettings.TimeZone, userSettings.PayDay);
            var isPayDay = evaluator.IsPayDay;
            var localTime = TimeZoneInfo.ConvertTime(utcTime, userSettings.TimeZone);
            return new PaydayResult(isPayDay, localTime);
        }

        public class Request
        {
            public int? PayDay { get; }
            public string CountryCode { get; }
            public string TimezoneId { get; }
            public DateTime UtcTime { get; }

            public Request(int? payDay, string countryCode, string timezoneId, DateTime utcTime)
            {
                PayDay = payDay;
                CountryCode = countryCode;
                TimezoneId = timezoneId;
                UtcTime = utcTime;
            }
        }
    }
}