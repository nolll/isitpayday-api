using System;
using Core.Classes;
using Core.DateEvaluators;
using Core.Storage;

namespace Core.Services
{
    public class PayDayService : IPayDayService
    {
        private const int DefaultPayDay = 25;
        private readonly IStorage _storage;
        private readonly IPayDayEvaluator _payDayEvaluator;
        private readonly ITimeService _timeService;

        public PayDayService(
            IStorage storage,
            IPayDayEvaluator payDayEvaluator,
            ITimeService timeService)
        {
            _storage = storage;
            _payDayEvaluator = payDayEvaluator;
            _timeService = timeService;
        }

        public bool IsPayDay(DateTime userTime, int payDay)
        {
            var actualPayDay = _payDayEvaluator.GetActualPayDay(userTime, payDay);
            return userTime.Day == actualPayDay.Day;
        }

        public bool IsPayDay(UserSettings userSettings)
        {
            var userTime = _timeService.GetTime(userSettings.TimeZone);
            var actualPayDay = _payDayEvaluator.GetActualPayDay(userTime, userSettings.PayDay);
            return userTime.Day == actualPayDay.Day;
        }

        public int GetSelectedPayDay()
        {
            var payday = _storage.GetPayDay();
            return payday.HasValue ? payday.Value : DefaultPayDay;
        }
    }
}