using System;
using AwesomeAssertions;
using Core.DateEvaluators;
using Tests.Common.FakeClasses;
using Xunit;

namespace Core.Tests.DateEvaluators.HolidayEvaluators;

public class SwedenTests
{
    [Theory]
    [InlineData("2014-01-01")]
    [InlineData("2015-01-01")]
    [InlineData("2016-01-01")]
    public void NewYearsDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-01-06")]
    [InlineData("2015-01-06")]
    [InlineData("2016-01-06")]
    public void EpiphanyIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-04-18")]
    [InlineData("2015-04-03")]
    [InlineData("2016-03-25")]
    public void GoodFridayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-04-21")]
    [InlineData("2015-04-06")]
    [InlineData("2016-03-28")]
    public void EasterMondayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-05-01")]
    [InlineData("2015-05-01")]
    [InlineData("2016-05-01")]
    public void InternationalWorkersDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-05-29")]
    [InlineData("2015-05-14")]
    [InlineData("2016-05-05")]
    public void AscensionDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-06-06")]
    [InlineData("2015-06-06")]
    [InlineData("2016-06-06")]
    public void NationalDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-06-20")]
    [InlineData("2015-06-19")]
    [InlineData("2016-06-24")]
    public void MidsummersEveIsHoliday(string date) => IsHoliday(date);

    [Theory]
    [InlineData("2014-12-24")]
    [InlineData("2015-12-24")]
    [InlineData("2016-12-24")]
    public void ChristmasEveIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-12-25")]
    [InlineData("2015-12-25")]
    [InlineData("2016-12-25")]
    public void ChristmasDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-12-26")]
    [InlineData("2015-12-26")]
    [InlineData("2016-12-26")]
    public void BoxingDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-12-31")]
    [InlineData("2015-12-31")]
    [InlineData("2016-12-31")]
    public void NewYearsEveIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-01-02")]
    [InlineData("2015-01-02")]
    [InlineData("2016-01-02")]
    public void AnyOtherDayIsNotHoliday(string date) => IsHoliday(date).Should().BeFalse();
    
    private static bool IsHoliday(string date) => 
        HolidayEvaluator.Create(new CountryInTest("SE", "sv-SE")).IsHoliday(DateTime.Parse(date));
}