namespace Web.Models
{
    public interface IPageModel
    {
        GoogleAnalyticsModel GoogleAnalyticsModel { get; }
        string Version { get; }
    }
}