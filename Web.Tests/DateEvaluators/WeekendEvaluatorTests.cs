using System;
using NUnit.Framework;
using Web.DateEvaluators;

namespace Web.Tests.DateEvaluators
{
    public class WeekendEvaluatorTests
    {
        [Test]
        public void IsWeekend_WithFriday_ReturnsFalse()
        {
            var friday = new DateTime(2014, 1, 17);

            var sut = GetSut();
            var result = sut.IsWeekend(friday);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsWeekend_WithSaturday_ReturnsTrue()
        {
            var saturday = new DateTime(2014, 1, 18);

            var sut = GetSut();
            var result = sut.IsWeekend(saturday);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsWeekend_WithSunday_ReturnsTrue()
        {
            var sunday = new DateTime(2014, 1, 19);

            var sut = GetSut();
            var result = sut.IsWeekend(sunday);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsWeekend_WithMonday_ReturnsFalse()
        {
            var monday = new DateTime(2014, 1, 20);

            var sut = GetSut();
            var result = sut.IsWeekend(monday);

            Assert.IsFalse(result);
        }

        private WeekendEvaluator GetSut()
        {
            return new WeekendEvaluator();
        }
    }
}
