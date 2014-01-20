using System;

namespace Core.DateEvaluators
{
    public class PayDayEvaluator : IPayDayEvaluator
    {
        private readonly IBlockedEvaluator _blockedEvaluator;

        public PayDayEvaluator(IBlockedEvaluator blockedEvaluator)
        {
            _blockedEvaluator = blockedEvaluator;
        }

        public DateTime GetActualPayDay(DateTime dateTime, int payDay)
        {
            var payDayDate = new DateTime(dateTime.Year, dateTime.Month, payDay);
            while (_blockedEvaluator.IsBlocked(payDayDate))
            {
                payDayDate = payDayDate.AddDays(-1);
            }
            return payDayDate;
        }
    }
}