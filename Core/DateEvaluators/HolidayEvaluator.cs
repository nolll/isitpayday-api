using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Core.Classes;
using Core.DateEvaluators.CountrySpecific;
using Core.HolidayRules;

namespace Core.DateEvaluators
{
    public abstract class HolidayEvaluator
    {
        protected abstract IEnumerable<HolidayRule> HolidayRules { get; }

        public bool IsHoliday(DateTime userTime)
        {
            return GetHolidays(userTime.Year).Contains(userTime.Date);
        }

        private List<DateTime> GetHolidays(int year)
        {
            return HolidayRules.Select(o => o.GetDate(year)).ToList();
        }

        public static HolidayEvaluator Create(Country country)
        {
            return Evaluators.TryGetValue(country.Id, out var evaluator) ? evaluator : new DefaultHolidayEvaluator();
        }

        public static readonly Dictionary<string, HolidayEvaluator> Evaluators = new Dictionary<string, HolidayEvaluator>
        {
            { CountryCode.Denmark, new DenmarkHolidayEvaluator() },
            { CountryCode.Norway, new NorwayHolidayEvaluator() },
            { CountryCode.Sweden, new SwedenHolidayEvaluator() },
            { CountryCode.UnitedStates, new UnitedStatesHolidayEvaluator() }
        };
    }
}