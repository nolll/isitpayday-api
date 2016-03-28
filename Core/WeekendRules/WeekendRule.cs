using System;

namespace Core.WeekendRules
{
    public class WeekendRule
    {
        public bool IsWeekend(DateTime userTime)
        {
            return userTime.DayOfWeek == DayOfWeek.Saturday || userTime.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}