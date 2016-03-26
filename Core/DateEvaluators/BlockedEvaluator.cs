using System;
using Core.Classes;

namespace Core.DateEvaluators
{
    public static class BlockedEvaluator
    {
        public static bool IsBlocked(Country country, DateTime userTime)
        {
            return WeekendEvaluator.IsWeekend(userTime) || HolidayEvaluator.IsHoliday(country, userTime);
        }
    }
}