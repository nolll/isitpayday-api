using System;

namespace Core.HolidayRules
{
    public class MidsummersEveRule : HolidayRule
    {
        protected override DateTime DetermineDate(int year)
        {
            var date = new DateTime(year, 6, 19);
            while (date.DayOfWeek != DayOfWeek.Friday)
                date = date.AddDays(1);
            return date;
        }
    }
}