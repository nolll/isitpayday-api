using System;
using Core.DateEvaluators;
using Core.Storage;

namespace Core.Services
{
    public class PayDayService : IPayDayService
    {
        private const int DefaultPayDay = 25;
        private readonly IStorage _storage;
        private readonly IPayDayEvaluator _payDayEvaluator;

        public PayDayService(
            IStorage storage,
            IPayDayEvaluator payDayEvaluator)
        {
            _storage = storage;
            _payDayEvaluator = payDayEvaluator;
        }

        public bool IsPayDay(DateTime dateTime, int payDay)
        {
            var actualPayDay = _payDayEvaluator.GetActualPayDay(dateTime, payDay);
            return dateTime.Day == actualPayDay.Day;
        }

        public int GetSelectedPayDay()
        {
            var payday = _storage.GetPayDay();
            return payday.HasValue ? payday.Value : DefaultPayDay;
        }
    }
}