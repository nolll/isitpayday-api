using Core.Classes;
using Core.Storage;

namespace Core.UseCases
{
    public class SaveSettings
    {
        private readonly IStorage _storage;

        public SaveSettings(IStorage storage)
        {
            _storage = storage;
        }

        public void Execute(SaveSettingsRequest request)
        {
            if (HasChanged(request.OldCountryId, request.NewCountryId))
            {
                _storage.SetCountry(request.NewCountryId);
            }
            if (HasChanged(request.OldTimeZoneId, request.NewTimeZoneId))
            {
                _storage.SetTimeZone(request.NewTimeZoneId);
            }
            if (HasChanged(request.OldPayDay, request.NewPayDay))
            {
                _storage.SetPayDay(request.NewPayDay.Value);
            }
            if (HasChanged(request.OldFrequency, request.NewFrequency))
            {
                var payDay = request.NewFrequency == (int) Frequency.Weekly ? (int) Weekday.Friday : 25;
                _storage.SetPayDay(payDay);
                _storage.SetFrequency(request.NewFrequency.Value);
            }
        }

        private bool HasChanged(int? oldValue, int? newValue)
        {
            return newValue.HasValue && newValue != oldValue;
        }

        private bool HasChanged(string oldValue, string newValue)
        {
            return !string.IsNullOrEmpty(newValue) && newValue != oldValue;
        }
    }
}