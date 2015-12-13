namespace Web.Models
{
    public class GoogleAnalyticsModel
    {
        public string Code { get; }
        public bool Enabled { get; }

        public GoogleAnalyticsModel(bool enabled)
        {
            Code = "UA-8453410-4";
            Enabled = enabled;
        }
    }
}