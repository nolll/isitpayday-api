using System;
using System.Collections.Generic;

namespace Core.Services
{
    public interface ITimeService
    {
        DateTime GetUtcTime();
        DateTime GetLocalTime(TimeZoneInfo timeZone);
        IEnumerable<TimeZoneInfo> GetTimezones();
        int GetCurrentYear();
    }
}