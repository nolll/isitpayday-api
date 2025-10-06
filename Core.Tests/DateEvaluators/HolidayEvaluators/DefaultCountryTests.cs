using System;
using AwesomeAssertions;
using Core.Classes;
using Core.DateEvaluators;
using Tests.Common.FakeClasses;
using Xunit;

namespace Core.Tests.DateEvaluators.HolidayEvaluators;

public class DefaultCountryTests
{
    [Fact]
    public void NewYearsDayIsNotHoliday() => IsHoliday("2016-01-01").Should().BeFalse();

    [Fact]
    public void EpiphanyIsNotHoliday() => IsHoliday("2016-01-06").Should().BeFalse();

    [Fact]
    public void GoodFridayIsNotHoliday() => IsHoliday("2016-03-25").Should().BeFalse();

    [Fact]
    public void EasterMondayIsNotHoliday() => IsHoliday("2016-03-28").Should().BeFalse();

    [Fact]
    public void AscensionDayIsNotHoliday() => IsHoliday("2016-05-05").Should().BeFalse();

    [Fact]
    public void ChristmasEveIsNotHoliday() => IsHoliday("2016-12-24").Should().BeFalse();

    [Fact]
    public void ChristmasDayIsNotHoliday() => IsHoliday("2016-12-25").Should().BeFalse();

    [Fact]
    public void BoxingDayIsNotHoliday() => IsHoliday("2016-12-26").Should().BeFalse();

    [Fact]
    public void NewYearsEveIsNotHoliday() => IsHoliday("2016-12-31").Should().BeFalse();

    [Fact]
    public void AnyOtherDayIsNotHoliday() => IsHoliday("2016-01-02").Should().BeFalse();

    private static bool IsHoliday(string date) => 
        HolidayEvaluator.Create(new CountryInTest()).IsHoliday(DateTime.Parse(date));
}