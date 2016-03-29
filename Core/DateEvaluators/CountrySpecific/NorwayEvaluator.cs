using System.Collections.Generic;
using Core.HolidayRules;

namespace Core.DateEvaluators.CountrySpecific
{
    public class NorwayEvaluator : CountryEvaluator
    {
        protected override List<HolidayRule> HolidayRules => new List<HolidayRule>
        {
            new NewYearsDayRule(),
            new MaundyThursdayRule(),
            new GoodFridayRule(),
            new EasterMondayRule(),
            new InternationalWorkersDayRule(),
            new AscensionDayRule(),
            new NationalDayNorwayRule(),
            new WhitMondayRule(),
            new ChristmasEveRule(),
            new ChristmasDayRule(),
            new BoxingDayRule(),
            new NewYearsEveRule()
        };
    }
}