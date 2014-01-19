using System;

namespace Web.DateEvaluators
{
    public class BlockedEvaluator : IBlockedEvaluator
    {
        private readonly IWeekendEvaluator _weekendEvaluator;
        private readonly IExcludedEvaluator _excludedEvaluator;

        public BlockedEvaluator(
            IWeekendEvaluator weekendEvaluator,
            IExcludedEvaluator excludedEvaluator)
        {
            _weekendEvaluator = weekendEvaluator;
            _excludedEvaluator = excludedEvaluator;
        }

        public bool IsBlocked(DateTime dateTime)
        {
            return _weekendEvaluator.IsWeekend(dateTime) || _excludedEvaluator.IsExcluded(dateTime);
        }
    }
}