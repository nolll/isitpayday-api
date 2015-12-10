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

        private UserSettingsService _userSettingsService;
        public UserSettingsService UserSettingsService
        {
            get { return _userSettingsService ?? (_userSettingsService = new UserSettingsService(Storage)); }
        }
    }
}