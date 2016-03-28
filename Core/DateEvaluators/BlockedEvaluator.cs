using System;
using Core.Classes;

namespace Core.DateEvaluators
{
    public static class BlockedEvaluator
    {
        public static bool IsBlocked(Country country, DateTime userTime)
        {
            var evaluator = CountryEvaluator.GetEvaluator(country);
            return evaluator.IsWeekend(userTime) || evaluator.IsHoliday(userTime);
        }
    }
}