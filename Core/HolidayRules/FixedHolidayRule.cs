using System;

namespace Core.HolidayRules
{
    public class FixedHolidayRule : IHolidayRule
    {
        private readonly int _month;
        private readonly int _day;

        public FixedHolidayRule(int month, int day)
        {
            _month = month;
            _day = day;
        }

        public DateTime GetDate(int year)
        {
            return new DateTime(year, _month, _day);
        }
    }
}