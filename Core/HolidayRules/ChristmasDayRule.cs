using Core.Classes;

namespace Core.HolidayRules
{
    public class ChristmasDayRule : FixedHolidayRule
    {
        public ChristmasDayRule() : base(Month.December, 25)
        {
        }
    }
}