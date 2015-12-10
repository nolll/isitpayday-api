using System;
using Core.DateEvaluators;
using NUnit.Framework;

namespace Core.Tests.DateEvaluators
{
    public class WeekendEvaluatorTests
    {
        [Test]
        public void IsWeekend_WithFriday_ReturnsFalse()
        {
            var friday = new DateTime(2014, 1, 17);

            var result = WeekendEvaluator.IsWeekend(friday);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsWeekend_WithSaturday_ReturnsTrue()
        {
            var saturday = new DateTime(2014, 1, 18);

            var result = WeekendEvaluator.IsWeekend(saturday);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsWeekend_WithSunday_ReturnsTrue()
        {
            var sunday = new DateTime(2014, 1, 19);

            var result = WeekendEvaluator.IsWeekend(sunday);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsWeekend_WithMonday_ReturnsFalse()
        {
            var monday = new DateTime(2014, 1, 20);

            var result = WeekendEvaluator.IsWeekend(monday);

            Assert.IsFalse(result);
        }
    }
}
