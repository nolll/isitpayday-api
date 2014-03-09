using System;

namespace Core.DateEvaluators
{
    public interface IPayDayEvaluator
    {
        DateTime GetActualPayDay(DateTime userTime, int payDay);
    }
}