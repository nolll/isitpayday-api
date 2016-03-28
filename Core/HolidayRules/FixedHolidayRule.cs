using System;
using Core.Classes;

namespace Core.HolidayRules
{
    public class FixedHolidayRule : HolidayRule
    {
        private readonly Month _month;
        private readonly int _day;

        protected FixedHolidayRule(Month month, int day)
        {
            _month = month;
            _day = day;
        }

        protected override DateTime DetermineDate(int year)
        {
            return new DateTime(year, (int)_month, _day);
        }
    }
}