using Core.UseCases.SaveSettings;

namespace Tests.Common.FakeClasses
{
    public class FakeSaveSettingsRequest : SaveSettingsRequest
    {
        public FakeSaveSettingsRequest(
            string countryId = default(string),
            string timeZoneId = default(string),
            int? payDay = default(int?))
            : base(countryId, timeZoneId, payDay)
        {
        }
    }
}