using Core.Classes;

namespace Core.HolidayRules
{
    public class ChristmasEveRule : FixedHolidayRule
    {
        public ChristmasEveRule() : base(Month.December, 24)
        {
        }
    }
}