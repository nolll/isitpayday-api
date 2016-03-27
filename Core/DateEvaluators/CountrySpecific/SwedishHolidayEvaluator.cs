using System.Collections.Generic;
using Core.HolidayRules;

namespace Core.DateEvaluators.CountrySpecific
{
    public class SwedishHolidayEvaluator : HolidayEvaluator
    {
        protected override List<IHolidayRule> HolidayRules => new List<IHolidayRule>
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