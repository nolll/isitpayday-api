using System;
using Core.Classes;

namespace Core.DateEvaluators
{
    public class BlockedEvaluator
    {
        private readonly WeekendEvaluator _weekendEvaluator;
        private readonly HolidayEvaluator _holidayEvaluator;

        public BlockedEvaluator(Country country)
        {
            _weekendEvaluator = new WeekendEvaluator();
            _holidayEvaluator = HolidayEvaluator.Create(country);
        }

        public bool IsBlocked(DateTime userTime)
        {
            return _weekendEvaluator.IsWeekend(userTime) || _holidayEvaluator.IsHoliday(userTime);
        }
    }
}