using System.Collections.Generic;
using Core.HolidayRules;

namespace Core.DateEvaluators.CountrySpecific
{
    public class DefaultHolidayEvaluator : HolidayEvaluator
    {
        protected override List<HolidayRule> HolidayRules => new List<HolidayRule>
        {
        };
    }
}