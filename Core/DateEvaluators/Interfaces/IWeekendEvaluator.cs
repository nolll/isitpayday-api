using System;

namespace Core.DateEvaluators
{
    public interface IWeekendEvaluator
    {
        bool IsWeekend(DateTime userTime);
    }
}