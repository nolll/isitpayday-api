using System;

namespace Core.DateEvaluators
{
    public class WeekendEvaluator : IWeekendEvaluator
    {
        public bool IsWeekend(DateTime userTime)
        {
            return userTime.DayOfWeek == DayOfWeek.Saturday || userTime.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}