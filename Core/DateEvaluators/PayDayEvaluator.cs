using System;

namespace Core.DateEvaluators
{
    public class PayDayEvaluator : IPayDayEvaluator
    {
        public DateTime GetActualPayDay(DateTime userTime, int payDay)
        {
            var payDayDate = new DateTime(userTime.Year, userTime.Month, payDay);
            while (BlockedEvaluator.IsBlocked(payDayDate))
            {
                payDayDate = payDayDate.AddDays(-1);
            }
            return payDayDate;
        }
    }
}