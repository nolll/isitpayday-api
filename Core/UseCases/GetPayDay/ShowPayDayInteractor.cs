using Core.Services;

namespace Core.UseCases.GetPayDay
{
    public class ShowPayDayInteractor : IShowPayDayInteractor
    {
        private readonly IPayDayService _payDayService;

        public ShowPayDayInteractor(
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