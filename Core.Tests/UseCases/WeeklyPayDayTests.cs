using AwesomeAssertions;
using Core.Classes;
using Core.UseCases;
using Tests.Common;
using Xunit;

namespace Core.Tests.UseCases;

public class WeeklyPayDayTests
{
    [Fact]
    public void Execute_TodayIsPayDay_IsTrue()
    {
        var request = new WeeklyPayday.Request((int)Weekday.Friday, "SE", TestData.Timezones.Utc, TestData.Dates.UnblockedFriday);

        var sut = GetSut();
        var result = sut.Execute(request);

        result.IsPayDay.Should().BeTrue();
    }

    [Fact]
    public void Execute_TodayIsNotPayDay_IsFalse()
    {
        var request = new WeeklyPayday.Request((int)Weekday.Thursday, "SE", TestData.Timezones.Utc, TestData.Dates.UnblockedFriday);

        var sut = GetSut();
        var result = sut.Execute(request);

        result.IsPayDay.Should().BeFalse();
    }

    [Fact]
    public void Execute_TomorrowIsChristmasEve_TodayIsPayday()
    {
        var request = new WeeklyPayday.Request((int)Weekday.Thursday, "SE", TestData.Timezones.Utc, TestData.Dates.DayBeforeChristmasEve);

        var sut = GetSut();
        var result = sut.Execute(request);

        result.IsPayDay.Should().BeTrue();
    }

    private WeeklyPayday GetSut()
    {
        return new WeeklyPayday();
    }
}