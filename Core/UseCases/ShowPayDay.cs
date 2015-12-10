using System;
using Core.Services;

namespace Core.UseCases
{
    public class ShowPayDay
    {
        private readonly IUserSettingsService _userSettingsService;
        private readonly ITimeService _timeService;

        public ShowPayDay(
            IUserSettingsService userSettingsService,
            ITimeService timeService)
        {
            _userSettingsService = userSettingsService;
            _timeService = timeService;
        }

        public Result Execute()
        {
            var utcTime = _timeService.GetUtcTime();
            var userSettings = _userSettingsService.GetSettings();
            var userTime = TimeService.GetLocalTime(utcTime, userSettings.TimeZone);
            var isPayDay = PayDayService.IsPayDay(utcTime, userSettings, userSettings.PayDay);
            var message = isPayDay ? "YES!!1!" : "No =(";
            return new Result(isPayDay, message, userTime);
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