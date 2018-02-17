using System;
using Core.WeekendRules;

namespace Core.DateEvaluators
{
    public class WeekendEvaluator
    {
        private readonly WeekendRule _weekendRule = new WeekendRule();

        public bool IsWeekend(DateTime userTime)
        {
            return _weekendRule.IsWeekend(userTime);
        }
    }
}