using Core.Services;

namespace Core.UseCases.GetPayDay
{
    public class GetPayDayInteractor
    {
        private readonly IPayDayService _payDayService;

        public GetPayDayInteractor(
            IPayDayService payDayService)
        {
            _payDayService = payDayService;
        }

        public GetPayDayResult Execute()
        {
            var isPayDay = _payDayService.IsPayDay();
            var message = isPayDay ? "YES!!1!" : "No =(";
            return new GetPayDayResult(isPayDay, message);
        }
    }
}