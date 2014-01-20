namespace Core.Storage
{
    public interface IStorage
    {
        int? GetPayDay();
        void SetPayDay(int payDay);
        string GetCountry();
        void SetCountry(string countryId);
        string GetTimeZone();
        void SetTimeZone(string timeZone);
    }
}