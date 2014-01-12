using Web.Services;

namespace Web.Storage
{
    public class CookieStorage : IStorage
    {
        private readonly IWebContext _webContext;

        public CookieStorage(
            IWebContext webContext)
        {
            _webContext = webContext;
        }

        public int? GetPayDay()
        {
            var value = _webContext.GetCookie("payday");
            int payday;
            if (value != null && int.TryParse(value, out payday))
            {
                return payday;
            }
            return null;
        }

        public void SavePayDay(int payDay)
        {
            _webContext.SetCookie("payday", payDay.ToString());
        }
    }
}