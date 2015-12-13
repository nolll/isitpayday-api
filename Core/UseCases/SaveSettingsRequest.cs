namespace Core.UseCases
{
    public class SaveSettingsRequest
    {
        public string CountryId { get; }
        public string TimeZoneId { get; }
        public int? PayDay { get; }

        public SaveSettingsRequest(
            string countryId,
            string timeZoneId,
            int? payDay)
        {
            CountryId = countryId;
            TimeZoneId = timeZoneId;
            PayDay = payDay;
        }
    }
}