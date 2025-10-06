using System;
using AwesomeAssertions;
using Core.WeekendRules;
using Xunit;

namespace Core.Tests.DateEvaluators;

public class WeekendRuleTests
{
    [Fact]
    public void IsWeekend_WithFriday_ReturnsFalse()
    {
        var friday = new DateTime(2014, 1, 17);

        var result = WeekendRule.IsWeekend(friday);

        result.Should().BeFalse();
    }

    [Fact]
    public void IsWeekend_WithSaturday_ReturnsTrue()
    {
        var saturday = new DateTime(2014, 1, 18);

        var result = WeekendRule.IsWeekend(saturday);

        result.Should().BeTrue();
    }

    [Fact]
    public void IsWeekend_WithSunday_ReturnsTrue()
    {
        var sunday = new DateTime(2014, 1, 19);

        var result = WeekendRule.IsWeekend(sunday);

        result.Should().BeTrue();
    }

    [Fact]
    public void IsWeekend_WithMonday_ReturnsFalse()
    {
        var monday = new DateTime(2014, 1, 20);

        var result = WeekendRule.IsWeekend(monday);

        result.Should().BeFalse();
    }
}