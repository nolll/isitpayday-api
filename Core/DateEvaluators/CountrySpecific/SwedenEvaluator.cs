using System.Collections.Generic;
using Core.HolidayRules;

namespace Core.DateEvaluators.CountrySpecific
{
    public class SwedenEvaluator : CountryEvaluator
    {
        protected override List<HolidayRule> HolidayRules => new List<HolidayRule>
        {
            new NewYearsDayRule(),
            new EpiphanyRule(),
            new GoodFridayRule(),
            new EasterMondayRule(),
            new InternationalWorkersDayRule(),
            new AscensionDayRule(),
            new MidsummersEveRule(),
            new SwedishNationalDayRule(),
            new ChristmasEveRule(),
            new ChristmasDayRule(),
            new BoxingDayRule(),
            new NewYearsEveRule()
        };
    }
}