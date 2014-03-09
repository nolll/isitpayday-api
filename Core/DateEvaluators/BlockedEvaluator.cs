﻿using System;

namespace Core.DateEvaluators
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

        public bool IsBlocked(DateTime userTime)
        {
            return _weekendEvaluator.IsWeekend(userTime) || _excludedEvaluator.IsExcluded(userTime);
        }
    }
}