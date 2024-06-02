using System;
using Core.Classes;

namespace Core.DateEvaluators;

public class BlockedEvaluator(Country country)
{
    private readonly HolidayEvaluator _holidayEvaluator = HolidayEvaluator.Create(country);

    public bool IsBlocked(DateTime userTime)
    {
        return WeekendEvaluator.IsWeekend(userTime) || _holidayEvaluator.IsHoliday(userTime);
    }
}