using System;
using Core.Classes;

namespace Core.HolidayRules
{
    public abstract class LastDayOfWeekInMonth : IHolidayRule
    {
        private readonly DayOfWeek _dayOfWeek;
        private readonly Month _month;

        protected LastDayOfWeekInMonth(DayOfWeek dayOfWeek, Month month)
        {
            _dayOfWeek = dayOfWeek;
            _month = month;
        }

        public DateTime GetDate(int year)
        {
            var firstOfMonth = new DateTime(year, (int)_month, 1);
            var firstOfNextMonth = firstOfMonth.AddMonths(1);
            var lastOfMonth = firstOfNextMonth.AddDays(-1);
            var date = lastOfMonth;
            while (date.DayOfWeek != _dayOfWeek)
            {
                date = date.AddDays(-1);
            }
            return date;
        }
    }
}