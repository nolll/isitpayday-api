using System;

namespace Core.DateEvaluators
{
    public class BlockedEvaluator : IBlockedEvaluator
    {
        public bool IsBlocked(DateTime userTime)
        {
            return WeekendEvaluator.IsWeekend(userTime) || ExcludedEvaluator.IsExcluded(userTime);
        }
    }
}