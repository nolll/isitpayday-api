using System;

namespace Core.DateEvaluators
{
    public static class PayDayEvaluator
    {
        public static DateTime GetActualPayDay(DateTime userTime, int payDay)
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