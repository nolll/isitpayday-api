using Core.Classes;

namespace Core.HolidayRules
{
    public class NewYearsDayRule : FixedHolidayRule
    {
        public NewYearsDayRule() : base(Month.January, 1)
        {
        }
    }
}