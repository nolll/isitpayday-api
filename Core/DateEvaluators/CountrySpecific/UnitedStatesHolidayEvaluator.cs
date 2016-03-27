using System.Collections.Generic;
using Core.HolidayRules;

namespace Core.DateEvaluators.CountrySpecific
{
    public class UnitedStatesHolidayEvaluator : HolidayEvaluator
    {
        protected override List<IHolidayRule> HolidayRules => new List<IHolidayRule>
        {
            new NewYearsDayRule().MoveSundayToMonday(),
            //Martin Luther King Jr.'s Birthday	January 18	January 16	January 15
            //Washington's Birthday	February 15	February 20	February 19
            //Memorial Day    May 30  May 29  May 28
            new IndependenceDayRule(),
            //Labor Day   September 5 September 4 September 3
            //Columbus Day    October 10  October 9   October 8
            //Veterans Day    November 11 November 11*    November 12**
            new ThanksgivingDayRule(),
            new ChristmasDayRule().MoveSundayToMonday()
        };
    }
}