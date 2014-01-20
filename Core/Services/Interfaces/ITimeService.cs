using System;
using System.Collections.Generic;

namespace Core.Services
{
    public interface ITimeService
    {
        DateTime GetTime();
        DateTime GetTime(TimeZoneInfo timeZone);
        IEnumerable<TimeZoneInfo> GetTimezones();
        int GetCurrentYear();
    }
}