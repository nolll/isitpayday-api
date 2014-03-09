﻿using System;
using System.Collections.Generic;
using Core.Services;

namespace Core.DateEvaluators
{
    public class ExcludedEvaluator : IExcludedEvaluator
    {
        private readonly ITimeService _timeService;

        public ExcludedEvaluator(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public bool IsExcluded(DateTime userTime)
        {
            return GetExcludedDates().Contains(userTime);
        }

        private IList<DateTime> GetExcludedDates()
        {
            var currentYear = _timeService.GetCurrentYear();

            return new List<DateTime>
                {
                    new DateTime(currentYear, 1, 1),
                    new DateTime(currentYear, 5, 1),
                    new DateTime(currentYear, 6, 6),
                    new DateTime(currentYear, 12, 24),
                    new DateTime(currentYear, 12, 25),
                    new DateTime(currentYear, 12, 31)
                };
        }
    }
}