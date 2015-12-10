using System;
using Core.DateEvaluators;

namespace Core.Services
{
    public class PayDayService : IPayDayService
    {
        private readonly ITimeService _timeService;
        private readonly IUserSettingsService _userSettingsService;

        public PayDayService(
            ITimeService timeService,
            IUserSettingsService userSettingsService)
        {
            _timeService = timeService;
            _userSettingsService = userSettingsService;
        }

        public bool IsPayDay(DateTime utcTime, int payDay)
        {
            var userSettings = _userSettingsService.GetSettings();
            var localTime = TimeService.GetLocalTime(utcTime, userSettings.TimeZone);
            var actualPayDay = PayDayEvaluator.GetActualPayDay(localTime, payDay);
            return localTime.Day == actualPayDay.Day;
        }

        public bool IsPayDay()
        {
            var userSettings = _userSettingsService.GetSettings();
            return IsPayDay(_timeService.GetUtcTime(), userSettings.PayDay);
        }
    }
}