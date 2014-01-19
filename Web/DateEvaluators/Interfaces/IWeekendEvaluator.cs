using System;

namespace Web.DateEvaluators
{
    public interface IWeekendEvaluator
    {
        bool IsWeekend(DateTime dateTime);
    }
}