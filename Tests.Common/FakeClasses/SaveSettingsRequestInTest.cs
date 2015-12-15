using Core.UseCases;

namespace Tests.Common.FakeClasses
{
    public class SaveSettingsRequestInTest : SaveSettings.Request
    {
        public SaveSettingsRequestInTest(
            string oldCountryId = default(string),
            string newCountryId = default(string),
            string oldTimeZoneId = default(string),
            string newTimeZoneId = default(string),
            int? oldPayDay = default(int?),
            int? newPayDay = default(int?),
            int? oldFrequency = default(int?),
            int? newFrequency = default(int?))
            : base(oldCountryId, newCountryId, oldTimeZoneId, newTimeZoneId, oldPayDay, newPayDay, oldFrequency, newFrequency)
        {
        }
    }
}