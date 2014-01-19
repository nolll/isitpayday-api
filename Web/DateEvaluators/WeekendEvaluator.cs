using System;

namespace Web.DateEvaluators
{
    public class WeekendEvaluator : IWeekendEvaluator
    {
        public bool IsWeekend(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}