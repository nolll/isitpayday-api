using System;
using Core.DateEvaluators;

namespace Core.Services
{
    public class PayDayService : IPayDayService
    {
        private readonly IPayDayEvaluator _payDayEvaluator;
        private readonly ITimeService _timeService;
        private readonly IUserSettingsService _userSettingsService;

        public PayDayService(
            IPayDayEvaluator payDayEvaluator,
            ITimeService timeService,
            IUserSettingsService userSettingsService)
        {
            _payDayEvaluator = payDayEvaluator;
            _timeService = timeService;
            _userSettingsService = userSettingsService;
        }

        public bool IsPayDay(DateTime userTime, int payDay)
        {
            var actualPayDay = _payDayEvaluator.GetActualPayDay(userTime, payDay);
            return userTime.Day == actualPayDay.Day;
        }

        public bool IsPayDay()
        {
            var userSettings = _userSettingsService.GetSettings();
            var userTime = _timeService.GetTime(userSettings.TimeZone);
            var actualPayDay = _payDayEvaluator.GetActualPayDay(userTime, userSettings.PayDay);
            return userTime.Day == actualPayDay.Day;
        }
    }
}