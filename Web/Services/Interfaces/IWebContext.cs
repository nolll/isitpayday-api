namespace Web.Services
{
    public interface IWebContext
    {
        string GetCookie(string name);
        void SetCookie(string name, string value);
        bool IsInProduction { get; }
    }
}