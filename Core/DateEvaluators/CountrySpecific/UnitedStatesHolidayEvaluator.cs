using System.Collections.Generic;
using Core.HolidayRules;

namespace Core.DateEvaluators.CountrySpecific
{
    public class UnitedStatesHolidayEvaluator : HolidayEvaluator
    {
        protected override List<IHolidayRule> HolidayRules => new List<IHolidayRule>
        {
            new NewYearsDayRule().MoveSundayToMonday(),
            new MartinLutherKingJrsBirthdayRule(),
            new PresidentsDayRule(),
            new MemorialDayRule(),
            new IndependenceDayRule(),
            new LaborDayRule(),
            new ColumbusDayRule(),
            new VeteransDayRule().MoveSundayToMonday().MoveSaturdayToFriday(),
            new ThanksgivingDayRule(),
            new ChristmasDayRule().MoveSundayToMonday()
        };
    }
}