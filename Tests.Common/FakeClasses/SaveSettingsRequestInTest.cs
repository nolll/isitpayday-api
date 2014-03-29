using Core.UseCases;

namespace Tests.Common.FakeClasses
{
    public class SaveSettingsRequestInTest : SaveSettingsRequest
    {
        public SaveSettingsRequestInTest(
            string countryId = default(string),
            string timeZoneId = default(string),
            int? payDay = default(int?))
            : base(countryId, timeZoneId, payDay)
        {
        }
    }
}