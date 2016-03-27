using Core.Classes;

namespace Core.HolidayRules
{
    public class IndependenceDayRule : FixedHolidayRule
    {
        public IndependenceDayRule() : base(Month.July, 4)
        {
        }
    }
}