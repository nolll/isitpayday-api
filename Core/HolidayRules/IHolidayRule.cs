using System;

namespace Core.HolidayRules
{
    public interface IHolidayRule
    {
        DateTime GetDate(int year);
    }
}