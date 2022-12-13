using System;

namespace Core.WeekendRules;

public static class WeekendRule
{
    public static bool IsWeekend(DateTime userTime)
    {
        return userTime.DayOfWeek == DayOfWeek.Saturday || userTime.DayOfWeek == DayOfWeek.Sunday;
    }
}