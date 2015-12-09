using Core.Storage;

namespace Core.UseCases
{
    public class SaveSettings
    {
        private readonly IStorage _storage;

        public SaveSettings(
            IStorage storage)
        {
            _storage = storage;
        }

        public void Execute(SaveSettingsRequest request)
        {
            if (!string.IsNullOrEmpty(request.CountryId))
            {
                _storage.SetCountry(request.CountryId);
            }
            if (!string.IsNullOrEmpty(request.TimeZoneId))
            {
                _storage.SetTimeZone(request.TimeZoneId);
            }
            if (request.PayDay.HasValue)
            {
                _storage.SetPayDay(request.PayDay.Value);
            }
        }
    }
}