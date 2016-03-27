using System;

namespace Core.HolidayRules
{
    public class MidsummersEveRule : IHolidayRule
    {
        public DateTime GetDate(int year)
        {
            var date = new DateTime(year, 6, 19);
            while (date.DayOfWeek != DayOfWeek.Friday)
                date = date.AddDays(1);
            return date;
        }
    }
}