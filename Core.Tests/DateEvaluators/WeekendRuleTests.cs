﻿using System;
using Core.DateEvaluators;
using Core.WeekendRules;
using NUnit.Framework;

namespace Core.Tests.DateEvaluators;

public class WeekendRuleTests
{
    [Test]
    public void IsWeekend_WithFriday_ReturnsFalse()
    {
        var friday = new DateTime(2014, 1, 17);

        var result = WeekendRule.IsWeekend(friday);

        Assert.That(result, Is.False);
    }

    [Test]
    public void IsWeekend_WithSaturday_ReturnsTrue()
    {
        var saturday = new DateTime(2014, 1, 18);

        var result = WeekendRule.IsWeekend(saturday);

        Assert.That(result, Is.True);
    }

    [Test]
    public void IsWeekend_WithSunday_ReturnsTrue()
    {
        var sunday = new DateTime(2014, 1, 19);

        var result = WeekendRule.IsWeekend(sunday);

        Assert.That(result, Is.True);
    }

    [Test]
    public void IsWeekend_WithMonday_ReturnsFalse()
    {
        var monday = new DateTime(2014, 1, 20);

        var result = WeekendRule.IsWeekend(monday);

        Assert.That(result, Is.False);
    }
}