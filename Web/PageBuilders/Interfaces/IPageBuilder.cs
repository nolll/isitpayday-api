using Web.Models;

namespace Web.PageBuilders
{
    public interface IPageBuilder
    {
        IndexPageModel Build();
    }
}