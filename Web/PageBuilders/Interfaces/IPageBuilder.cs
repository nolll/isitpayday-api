using Core.UseCases;
using Web.Models;

namespace Web.PageBuilders
{
    public interface IPageBuilder
    {
        IndexPageModel Build(ShowPayDay.Result showPayDayResult, string activeForm = null);
    }
}