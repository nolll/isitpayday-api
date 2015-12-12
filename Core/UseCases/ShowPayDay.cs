using System;
using Core.Services;

namespace Core.UseCases
{
    public class ShowPayDay
    {
        public Result Execute(Request request)
        {
            var payDay = UserSettingsService.GetSelectedPayDay(request.PayDay);
            var utcTime = request.UtcTime;
            var userSettings = UserSettingsService.GetSettings(request.PayDay, request.PayDayType, request.CountryCode, request.TimezoneId);
            var userTime = TimeZoneInfo.ConvertTime(utcTime, userSettings.TimeZone);
            var isPayDay = PayDayService.IsPayDay(utcTime, userSettings, payDay);
            var message = isPayDay ? "YES!!1!" : "No =(";
            return new Result(isPayDay, message, userTime);
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
            public string Message { get; }
            public DateTime UserTime { get; }

            public Result(bool isPayDay, string message, DateTime userTime)
            {
                IsPayDay = isPayDay;
                Message = message;
                UserTime = userTime;
            }
        }
    }
}