using Core.Classes;

namespace Core.HolidayRules
{
    public class IndependenceDayRule : FixedDate
    {
        public IndependenceDayRule() : base(Month.July, 4)
        {
        }
    }
}