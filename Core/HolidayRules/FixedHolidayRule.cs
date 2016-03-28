using System;
using Core.Classes;

namespace Core.HolidayRules
{
    public class FixedHolidayRule : IHolidayRule
    {
        private readonly Month _month;
        private readonly int _day;
        private bool _moveSundayToMonday;
        private bool _moveSaturdayToFriday;

        protected FixedHolidayRule(Month month, int day)
        {
            _month = month;
            _day = day;
        }

        public DateTime GetDate(int year)
        {
            var date = new DateTime(year, (int)_month, _day);
            if (_moveSundayToMonday && date.DayOfWeek == DayOfWeek.Sunday)
                return date.AddDays(1);
            if (_moveSaturdayToFriday && date.DayOfWeek == DayOfWeek.Saturday)
                return date.AddDays(-1);
            return date;
        }

        public FixedHolidayRule MoveSundayToMonday()
        {
            _moveSundayToMonday = true;
            return this;
        }

        public FixedHolidayRule MoveSaturdayToFriday()
        {
            _moveSaturdayToFriday = true;
            return this;
        }
    }
}