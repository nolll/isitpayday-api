using System;

namespace Core.DateEvaluators
{
    public static class WeekendEvaluator
    {
        public static bool IsWeekend(DateTime userTime)
        {
            return userTime.DayOfWeek == DayOfWeek.Saturday || userTime.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}