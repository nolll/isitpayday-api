namespace Web.Models
{
    public class GoogleAnalyticsModel
    {
        public string Code { get; private set; }
        public bool Enabled { get; private set; }

        public GoogleAnalyticsModel(bool enabled)
        {
            Code = "UA-8453410-4";
            Enabled = enabled;
        }
    }
}