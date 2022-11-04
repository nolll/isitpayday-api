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

        Assert.AreEqual("01:00:00", timezone.BaseUtcOffset.ToString());
    }

    [Test]
    public void GetTimezone_IanaTimezoneId_ReturnsIanaTimezone()
    {
        var timezone = TimezoneService.GetTimezone(TestData.Timezones.IanaEuropeStockholm);

        Assert.AreEqual("01:00:00", timezone.BaseUtcOffset.ToString());
    }

    [Test]
    public void GetTimezone_InvalidTimezoneId_ThrowsException()
    {
        Assert.Throws<TimeZoneNotFoundException>(() => TimezoneService.GetTimezone(TestData.Timezones.Invalid));
    }
}