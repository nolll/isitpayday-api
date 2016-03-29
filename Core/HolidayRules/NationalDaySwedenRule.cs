using Core.Classes;

namespace Core.HolidayRules
{
    public class NationalDaySwedenRule : FixedDate
    {
        public NationalDaySwedenRule() : base(Month.June, 6)
        {
        }
    }

    public class NationalDayNorwayRule : FixedDate
    {
        public NationalDayNorwayRule() : base(Month.May, 17)
        {
        }
    }
}