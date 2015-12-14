namespace Core.UseCases
{
    public class SaveSettingsRequest
    {
        public string OldCountryId { get; }
        public string NewCountryId { get; }
        public string OldTimeZoneId { get; }
        public string NewTimeZoneId { get; }
        public int? OldPayDay { get; }
        public int? NewPayDay { get; }
        public int? OldFrequency { get; }
        public int? NewFrequency { get; }

        public SaveSettingsRequest(
            string oldCountryId,
            string newCountryId,
            string oldTimeZoneId,
            string newTimeZoneId,
            int? oldPayDay,
            int? newPayDay,
            int? oldFrequency,
            int? newFrequency)
        {
            OldCountryId = oldCountryId;
            NewCountryId = newCountryId;
            OldTimeZoneId = oldTimeZoneId;
            NewTimeZoneId = newTimeZoneId;
            OldPayDay = oldPayDay;
            NewPayDay = newPayDay;
            OldFrequency = oldFrequency;
            NewFrequency = newFrequency;
        }
    }
}