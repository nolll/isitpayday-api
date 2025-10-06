using System;
using AwesomeAssertions;
using Core.DateEvaluators;
using Tests.Common.FakeClasses;
using Xunit;

namespace Core.Tests.DateEvaluators.HolidayEvaluators;

public class NorwayTests
{
    [Theory]
    [InlineData("2014-01-01")]
    [InlineData("2015-01-01")]
    [InlineData("2016-01-01")]
    public void NewYearsDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-04-17")]
    [InlineData("2015-04-02")]
    [InlineData("2016-03-24")]
    public void MaundyThursdayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

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
    [InlineData("2014-05-17")]
    [InlineData("2015-05-17")]
    [InlineData("2016-05-17")]
    public void NationalDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-06-09")]
    [InlineData("2015-05-25")]
    [InlineData("2016-05-16")]
    public void WhitMondayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

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
    
    private static bool IsHoliday(string date) => 
        HolidayEvaluator.Create(new CountryInTest("NO", "nb-NO")).IsHoliday(DateTime.Parse(date));
}