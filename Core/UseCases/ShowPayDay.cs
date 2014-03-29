using Core.Services;

namespace Core.UseCases
{
    public class ShowPayDay : IShowPayDay
    {
        private readonly IPayDayService _payDayService;

        public ShowPayDay(
            IPayDayService payDayService)
        {
            _payDayService = payDayService;
        }

        public ShowPayDayResult Execute()
        {
            var isPayDay = _payDayService.IsPayDay();
            var message = isPayDay ? "YES!!1!" : "No =(";
            return new ShowPayDayResult(isPayDay, message);
        }
    }
}