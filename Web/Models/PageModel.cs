namespace Web.Models
{
    public class PageModel
    {
        public GoogleAnalyticsModel GoogleAnalyticsModel { get; }
        public string Version { get; }
        public static string StyleView => "~/Views/Generated/Style.cshtml";
        public static string ScriptView => "~/Views/Generated/Script.cshtml";

        public PageModel(bool isInProduction)
        {
            GoogleAnalyticsModel = new GoogleAnalyticsModel(isInProduction);
            Version = AppSettings.Version;
        }
    }
}