using System;
using AwesomeAssertions;
using Core.Services;
using Tests.Common;
using Xunit;

namespace Core.Tests.Services;

public class TimezoneServiceTests
{
    [Fact]
    public void GetTimezone_WindowsTimezoneId_ReturnsTimezone()
    {
        var timezone = TimezoneService.GetTimezone(TestData.Timezones.WindowsWesternEurope);

        timezone.BaseUtcOffset.ToString().Should().Be("01:00:00");
    }

    [Fact]
    public void GetTimezone_IanaTimezoneId_ReturnsIanaTimezone()
    {
        var timezone = TimezoneService.GetTimezone(TestData.Timezones.IanaEuropeStockholm);

        timezone.BaseUtcOffset.ToString().Should().Be("01:00:00");
    }

    [Fact]
    public void GetTimezone_InvalidTimezoneId_ThrowsException()
    {
        Assert.Throws<TimeZoneNotFoundException>(() => TimezoneService.GetTimezone(TestData.Timezones.Invalid));
    }
}