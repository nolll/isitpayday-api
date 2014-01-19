using System;
using System.Collections.Generic;
using Web.Services;

namespace Web.DateEvaluators
{
    public class ExcludedEvaluator : IExcludedEvaluator
    {
        private readonly ITimeService _timeService;

        public ExcludedEvaluator(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public bool IsExcluded(DateTime dateTime)
        {
            return GetExcludedDates().Contains(dateTime);
        }

        private IList<DateTime> GetExcludedDates()
        {
            var currentYear = _timeService.GetCurrentYear();

            return new List<DateTime>
                {
                    new DateTime(currentYear, 1, 1),
                    new DateTime(currentYear, 5, 1),
                    new DateTime(currentYear, 12, 24),
                    new DateTime(currentYear, 12, 25)
                };
        }
    }
}