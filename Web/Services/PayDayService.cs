using Web.Storage;

namespace Web.Services
{
    public class PayDayService : IPayDayService
    {
        private const int DefaultPayDay = 25;
        private readonly IStorage _storage;
        private readonly ITimeService _timeService;

        public PayDayService(
            IStorage storage,
            ITimeService timeService)
        {
            _storage = storage;
            _timeService = timeService;
        }

        public bool IsPayDay
        {
            get
            {
                var currentTime = _timeService.GetTime();
                var currentDay = currentTime.Day;
                var payDay = GetPayDay();
                return currentDay == payDay;
            }
        }

        public int GetPayDay()
        {
            var payday = _storage.GetPayDay();
            return payday.HasValue ? payday.Value : DefaultPayDay;
        }
    }
}