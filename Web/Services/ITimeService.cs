using System;

namespace Web.Services
{
    public interface ITimeService
    {
        DateTime GetTime();
        DateTime GetTime(TimeZoneInfo timeZone);
        DateTime Parse(string str, TimeZoneInfo timezone = null);
        DateTime ConvertToUtc(DateTime dateTime);
    }
}