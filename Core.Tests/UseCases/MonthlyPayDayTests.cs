using System;
using AwesomeAssertions;
using Core.UseCases;
using Tests.Common;
using Xunit;

namespace Core.Tests.UseCases;

public class MonthlyPayDayTests
{
    [Fact]
    public void Execute_TodayIsPayDay_IsTrue()
    {
        var time = new DateTime(2000, 1, 25, 12, 0, 0, DateTimeKind.Utc);
        var request = new MonthlyPayday.Request(25, "SE", "UTC", time);

        var sut = GetSut();
        var result = sut.Execute(request);

        result.IsPayDay.Should().BeTrue();
    }

    [Fact]
    public void Execute_TodayIsNotPayDay_IsFalse()
    {
        var time = new DateTime(2000, 1, 24, 12, 0, 0, DateTimeKind.Utc);
        var request = new MonthlyPayday.Request(25, "SE", "UTC", time);

        var sut = GetSut();
        var result = sut.Execute(request);

        result.IsPayDay.Should().BeFalse();
    }

    [Fact]
    public void Execute_TodayIsNotPayDayButMonthIsTooShortAndFallbacks_IsTrue()
    {
        var request = new MonthlyPayday.Request(31, "SE", "UTC", TestData.Dates.LeapYearFeb29);

        var sut = GetSut();
        var result = sut.Execute(request);

        result.IsPayDay.Should().BeTrue();
    }

    [Fact]
    public void Execute_UserTimeIsSet()
    {
        var time = new DateTime(2000, 1, 1, 12, 0, 0, DateTimeKind.Utc);
        var request = new MonthlyPayday.Request(25, "SE", "UTC", time);

        var sut = GetSut();
        var result = sut.Execute(request);

        // todo: test one more time zone
        result.LocalTime.Should().Be(time);
    }

    private MonthlyPayday GetSut()
    {
        return new MonthlyPayday();
    }
}