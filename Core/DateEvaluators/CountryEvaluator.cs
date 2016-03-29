using System;
using System.Collections.Generic;
using System.Linq;
using Core.Classes;
using Core.DateEvaluators.CountrySpecific;
using Core.HolidayRules;
using Core.WeekendRules;

namespace Core.DateEvaluators
{
    public abstract class CountryEvaluator
    {
        private readonly WeekendRule _weekendRule = new WeekendRule();
        protected abstract List<HolidayRule> HolidayRules { get; }

        public bool IsWeekend(DateTime userTime)
        {
            return _weekendRule.IsWeekend(userTime);
        }

        public bool IsHoliday(DateTime userTime)
        {
            return GetHolidays(userTime.Year).Contains(userTime.Date);
        }

        private List<DateTime> GetHolidays(int year)
        {
            return HolidayRules.Select(o => o.GetDate(year)).ToList();
        }

        public static CountryEvaluator GetEvaluator(Country country)
        {
            CountryEvaluator evaluator;
            if(Evaluators.TryGetValue(country.Id, out evaluator))
                return evaluator;
            return new DefaultEvaluator();
        }

        private static readonly Dictionary<string, CountryEvaluator> Evaluators = new Dictionary<string, CountryEvaluator>
        {
            { "SE", new SwedenEvaluator() },
            { "NO", new NorwayEvaluator() },
            { "US", new UnitedStatesEvaluator() }
        };
    }
}