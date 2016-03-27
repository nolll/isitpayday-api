using Core.Classes;

namespace Core.HolidayRules
{
    public class NewYearsEveRule : FixedHolidayRule
    {
        public NewYearsEveRule() : base(Month.December, 31)
        {
        }
    }
}