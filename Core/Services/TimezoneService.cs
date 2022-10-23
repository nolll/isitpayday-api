using System;
using System.Linq;
using Core.Exceptions;
using TimeZoneConverter;

namespace Core.Services;

public static class TimezoneService
{
    public static TimeZoneInfo GetTimezone(string id)
    {
        var timezone = GetWindowsTimezone(id);
        if (timezone != null)
            return timezone;

        timezone = GetIanaTimezone(id);
        if (timezone != null)
            return timezone;

        throw new TimezoneNotFoundException(id);
    }

    private static TimeZoneInfo GetWindowsTimezone(string id)
    {
        var foundId = TZConvert.KnownWindowsTimeZoneIds.FirstOrDefault(o => o == id);
        return foundId == null ? null : TimeZoneInfo.FindSystemTimeZoneById(foundId);
    }

    private static TimeZoneInfo GetIanaTimezone(string ianaId)
    {
        try
        {
            var windowsId = TZConvert.IanaToWindows(ianaId);
            return GetWindowsTimezone(windowsId);
        }
        catch (InvalidTimeZoneException)
        {
            return null;
        }
    }
}