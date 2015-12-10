using System;
using Core.Services;

namespace Core.UseCases
{
    public class ShowPayDay
    {
        private readonly IPayDayService _payDayService;
        private readonly IUserSettingsService _userSettingsService;
        private readonly ITimeService _timeService;

        public ShowPayDay(
            IPayDayService payDayService,
            IUserSettingsService userSettingsService,
            ITimeService timeService)
        {
            _payDayService = payDayService;
            _userSettingsService = userSettingsService;
            _timeService = timeService;
        }

        public Result Execute()
        {
            var userSettings = _userSettingsService.GetSettings();
            var userTime = _timeService.GetLocalTime(userSettings.TimeZone);
            var isPayDay = _payDayService.IsPayDay();
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