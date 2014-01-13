using System;
using Web.Storage;

namespace Web.Services
{
    public class PayDayService : IPayDayService
    {
        private const int DefaultPayDay = 25;
        private readonly IStorage _storage;
        private readonly ITimeService _timeService;
        private readonly ICountryService _countryService;

        public PayDayService(
            IStorage storage,
            ITimeService timeService,
            ICountryService countryService)
        {
            _storage = storage;
            _timeService = timeService;
            _countryService = countryService;
        }

        public bool IsPayDay()
        {
            var timeZone = _countryService.GetTimeZone();
            var currentTime = _timeService.GetTime(timeZone);
            return IsPayDay(currentTime);
        }

        public bool IsPayDay(DateTime dateTime)
        {
            var currentDay = dateTime.Day;
            var payDay = GetPayDay();
            return currentDay == payDay;
        }

        public int GetPayDay()
        {
            var payday = _storage.GetPayDay();
            return payday.HasValue ? payday.Value : DefaultPayDay;
        }
    }
}