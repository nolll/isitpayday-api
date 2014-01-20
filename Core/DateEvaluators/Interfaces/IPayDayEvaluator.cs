using System;

namespace Core.DateEvaluators
{
    public interface IPayDayEvaluator
    {
        DateTime GetActualPayDay(DateTime dateTime, int payDay);
    }
}