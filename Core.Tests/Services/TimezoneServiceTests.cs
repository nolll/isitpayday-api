using System;
using Core.Exceptions;
using Core.Services;
using NUnit.Framework;
using Tests.Common;

namespace Core.Tests.Services;

public class TimezoneServiceTests
{
    [Test]
    public void GetTimezone_WindowsTimezoneId_ReturnsTimezone()
    {
        var timezone = TimezoneService.GetTimezone(TestData.Timezones.WindowsWesternEurope);

        Assert.That(timezone.BaseUtcOffset.ToString(), Is.EqualTo("01:00:00"));
    }

    [Test]
    public void GetTimezone_IanaTimezoneId_ReturnsIanaTimezone()
    {
        var timezone = TimezoneService.GetTimezone(TestData.Timezones.IanaEuropeStockholm);

        Assert.That(timezone.BaseUtcOffset.ToString(), Is.EqualTo("01:00:00"));
    }

    [Test]
    public void GetTimezone_InvalidTimezoneId_ThrowsException()
    {
        Assert.Throws<TimeZoneNotFoundException>(() => TimezoneService.GetTimezone(TestData.Timezones.Invalid));
    }
}