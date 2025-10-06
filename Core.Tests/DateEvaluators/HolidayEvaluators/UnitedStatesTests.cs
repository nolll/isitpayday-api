using System;
using AwesomeAssertions;
using Core.DateEvaluators;
using Tests.Common.FakeClasses;
using Xunit;

namespace Core.Tests.DateEvaluators.HolidayEvaluators;

public class UnitedStatesTests
{
    [Theory]
    [InlineData("2014-01-01")]
    [InlineData("2015-01-01")]
    [InlineData("2016-01-01")]
    [InlineData("2017-01-02")]
    [InlineData("2018-01-01")]
    public void NewYearsDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-01-20")]
    [InlineData("2015-01-19")]
    [InlineData("2016-01-18")]
    [InlineData("2017-01-16")]
    [InlineData("2018-01-15")]
    public void MartinLutherKingJrsBirthdayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-02-17")]
    [InlineData("2015-02-16")]
    [InlineData("2016-02-15")]
    [InlineData("2017-02-20")]
    [InlineData("2018-02-19")]
    public void PresidentsDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-05-26")]
    [InlineData("2015-05-25")]
    [InlineData("2016-05-30")]
    [InlineData("2017-05-29")]
    [InlineData("2018-05-28")]
    public void MemorialDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-07-04")]
    [InlineData("2015-07-04")]
    [InlineData("2016-07-04")]
    [InlineData("2017-07-04")]
    [InlineData("2018-07-04")]
    public void IndependenceDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-09-01")]
    [InlineData("2015-09-07")]
    [InlineData("2016-09-05")]
    [InlineData("2017-09-04")]
    [InlineData("2018-09-03")]
    public void LaborDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-10-13")]
    [InlineData("2015-10-12")]
    [InlineData("2016-10-10")]
    [InlineData("2017-10-09")]
    [InlineData("2018-10-08")]
    public void ColumbusDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-11-11")]
    [InlineData("2015-11-11")]
    [InlineData("2016-11-11")]
    [InlineData("2017-11-10")]
    [InlineData("2018-11-12")]
    public void VeteransDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-11-27")]
    [InlineData("2015-11-26")]
    [InlineData("2016-11-24")]
    [InlineData("2017-11-23")]
    [InlineData("2018-11-22")]
    public void ThanksgivingDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();

    [Theory]
    [InlineData("2014-12-25")]
    [InlineData("2015-12-25")]
    [InlineData("2016-12-26")]
    [InlineData("2017-12-25")]
    [InlineData("2018-12-25")]
    public void ChristmasDayIsHoliday(string date) => IsHoliday(date).Should().BeTrue();
    
    private static bool IsHoliday(string date) => 
        HolidayEvaluator.Create(new CountryInTest("US", "en-US")).IsHoliday(DateTime.Parse(date));
}