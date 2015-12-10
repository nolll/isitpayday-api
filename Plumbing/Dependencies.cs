using Core.DateEvaluators;
using Core.Services;
using Core.Storage;

namespace Plumbing
{
    public class Dependencies
    {
        public IStorage Storage { get; private set; }

        public Dependencies(IStorage storage)
        {
            Storage = storage;
        }

        private PayDayService _payDayService;
        public PayDayService PayDayService
        {
            get { return _payDayService ?? (_payDayService = new PayDayService(PayDayEvaluator, TimeService, UserSettingsService)); }
        }

        private PayDayEvaluator _payDayEvaluator;
        public PayDayEvaluator PayDayEvaluator
        {
            get { return _payDayEvaluator ?? (_payDayEvaluator = new PayDayEvaluator()); }
        }

        private TimeService _timeService;
        public TimeService TimeService
        {
            get { return _timeService ?? (_timeService = new TimeService()); }
        }

        private UserSettingsService _userSettingsService;
        public UserSettingsService UserSettingsService
        {
            get { return _userSettingsService ?? (_userSettingsService = new UserSettingsService(CountryService, TimeService, Storage)); }
        }

        private CountryService _countryService;
        public CountryService CountryService
        {
            get { return _countryService ?? (_countryService = new CountryService()); }
        }
    }
}