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
            var utcTime = request.UtcTime;
            var userSettings = _userSettingsService.GetSettings();
            var userTime = TimeZoneInfo.ConvertTime(utcTime, userSettings.TimeZone);
            var isPayDay = PayDayService.IsPayDay(utcTime, userSettings, userSettings.PayDay);
            var message = isPayDay ? "YES!!1!" : "No =(";
            return new Result(isPayDay, message, userTime);
        }

        public class Request
        {
            public DateTime UtcTime { get; private set; }

            public Request(DateTime utcTime)
            {
                UtcTime = utcTime;
            }
        }

        public class Result
        {
            public bool IsPayDay { get; private set; }
            public string Message { get; private set; }
            public DateTime UserTime { get; private set; }

            public Result(bool isPayDay, string message, DateTime userTime)
            {
                IsPayDay = isPayDay;
                Message = message;
                UserTime = userTime;
            }
        }
    }
}