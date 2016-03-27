using Core.Classes;

namespace Core.HolidayRules
{
    public class BoxingDayRule : FixedHolidayRule
    {
        public BoxingDayRule() : base(Month.December, 26)
        {
        }
    }
}