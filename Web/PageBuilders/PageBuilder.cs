using Web.Models;
using Web.Services;

namespace Web.PageBuilders
{
    public class PageBuilder : IPageBuilder
    {
        private readonly IPayDayService _payDayService;

        public PageBuilder(IPayDayService payDayService)
        {
            _payDayService = payDayService;
        }

        public IndexPageModel Build()
        {
            var payDayString = _payDayService.IsPayDay ? "YES!!1!" : "No =(";

            return new IndexPageModel(payDayString);
        }
    }
}