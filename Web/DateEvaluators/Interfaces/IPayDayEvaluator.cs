using System;

namespace Web.DateEvaluators
{
    public interface IPayDayEvaluator
    {
        DateTime GetActualPayDay(DateTime dateTime, int payDay);
    }
}