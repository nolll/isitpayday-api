using System;
using System.Collections.Generic;

namespace Core.DateEvaluators
{
    public static class ExcludedEvaluator
    {
        public static bool IsExcluded(DateTime userTime)
        {
            return GetExcludedDates(userTime.Year).Contains(userTime.Date);
        }

        private static IList<DateTime> GetExcludedDates(int year)
        {
            return new List<DateTime>
            {
                new DateTime(year, 1, 1),
                new DateTime(year, 5, 1),
                new DateTime(year, 6, 6),
                new DateTime(year, 12, 24),
                new DateTime(year, 12, 25),
                new DateTime(year, 12, 31)
            };
        }
    }
}