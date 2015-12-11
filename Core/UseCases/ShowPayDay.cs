using System;
using Core.Services;

namespace Core.UseCases
{
    public class ShowPayDay
    {
        private readonly IUserSettingsService _userSettingsService;

        public ShowPayDay(IUserSettingsService userSettingsService)
        {
            _userSettingsService = userSettingsService;
        }

        public Result Execute(Request request)
        {
            var payDay = UserSettingsService.GetSelectedPayDay(request.PayDay);
            var utcTime = request.UtcTime;
            var userSettings = _userSettingsService.GetSettings();
            var userTime = TimeZoneInfo.ConvertTime(utcTime, userSettings.TimeZone);
            var isPayDay = PayDayService.IsPayDay(utcTime, userSettings, payDay);
            var message = isPayDay ? "YES!!1!" : "No =(";
            return new Result(isPayDay, message, userTime);
        }

        public class Request
        {
            public int? PayDay { get; }
            public DateTime UtcTime { get; }

            public Request(int? payDay, DateTime utcTime)
            {
                PayDay = payDay;
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