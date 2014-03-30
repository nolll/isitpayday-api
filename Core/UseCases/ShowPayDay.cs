using System;
using Core.Services;

namespace Core.UseCases
{
    public class ShowPayDay : IShowPayDay
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

        public ShowPayDayResult Execute()
        {
            var isPayDay = _payDayService.IsPayDay();
            var message = isPayDay ? "YES!!1!" : "No =(";
            var userTime = GetUserTime();
            return new ShowPayDayResult(isPayDay, message, userTime);
        }

        private DateTime GetUserTime()
        {
            var userSettings = _userSettingsService.GetSettings();
            return _timeService.GetTime(userSettings.TimeZone);
        }
    }
}