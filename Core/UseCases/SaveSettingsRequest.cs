namespace Core.UseCases
{
    public class SaveSettingsRequest
    {
        public string CountryId { get; private set; }
        public string TimeZoneId { get; private set; }
        public int? PayDay { get; private set; }

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