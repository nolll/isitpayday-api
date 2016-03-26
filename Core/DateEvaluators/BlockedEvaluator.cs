using System;

namespace Core.DateEvaluators
{
    public static class BlockedEvaluator
    {
        public static bool IsBlocked(DateTime userTime)
        {
            return WeekendEvaluator.IsWeekend(userTime) || HolidayEvaluator.IsHoliday(userTime);
        }
    }
}