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

        public bool IsPayDay(DateTime userTime, int payDay)
        {
            var actualPayDay = PayDayEvaluator.GetActualPayDay(userTime, payDay);
            return userTime.Day == actualPayDay.Day;
        }

        public bool IsPayDay()
        {
            var userSettings = _userSettingsService.GetSettings();
            var userTime = _timeService.GetTime(userSettings.TimeZone);
            var actualPayDay = PayDayEvaluator.GetActualPayDay(userTime, userSettings.PayDay);
            return userTime.Day == actualPayDay.Day;
        }
    }
}