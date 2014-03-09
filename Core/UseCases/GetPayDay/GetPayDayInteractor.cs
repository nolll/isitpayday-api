using System;
using Core.Classes;
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

        public GetPayDayResult Execute(UserSettings userSettings)
        {
            var isPayDay = _payDayService.IsPayDay(userSettings);
            var message = isPayDay ? "YES!!1!" : "No =(";
            return new GetPayDayResult(isPayDay, message);
        }
    }
}