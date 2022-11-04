using System;

namespace Core.Services;

public static class TimezoneService
{
    public static TimeZoneInfo GetTimezone(string id)
    {
        return TimeZoneInfo.FindSystemTimeZoneById(id);
    }
}