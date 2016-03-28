using System.Collections.Generic;
using Core.HolidayRules;

namespace Core.DateEvaluators.CountrySpecific
{
    public class DefaultEvaluator : CountryEvaluator
    {
        protected override List<HolidayRule> HolidayRules => new List<HolidayRule>
        {
        };
    }
}