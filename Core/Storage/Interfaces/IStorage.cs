namespace Core.Storage
{
    public interface IStorage
    {
        void SetPayDay(int payDay);
        void SetCountry(string countryId);
        void SetTimeZone(string timeZone);
    }
}