using System;
using Core.Classes;
using Core.DateEvaluators;
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;

namespace Core.Tests.DateEvaluators
{
    public class HolidayEvaluatorTests : MockContainer
    {
        private readonly Country _country = new CountryInTest();

        [Test]
        public void IsHoliday_WithNonHolidayDate_ReturnsFalse()
        {
            const int currentYear = 1;
            var input = new DateTime(currentYear, 1, 2);

            var result = HolidayEvaluator.IsHoliday(_country, input);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsHoliday_WithFixedHolidayDate_ReturnsTrue()
        {
            const int currentYear = 1;
            var input = new DateTime(currentYear, 1, 1);

            var result = HolidayEvaluator.IsHoliday(_country, input);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsHoliday_WithGoodFridayDate_ReturnsTrue()
        {
            var input = new DateTime(2016, 3, 25);

            var result = HolidayEvaluator.IsHoliday(_country, input);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsHoliday_WithEasterMondayDate_ReturnsTrue()
        {
            var input = new DateTime(2016, 3, 28);

            var result = HolidayEvaluator.IsHoliday(_country, input);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsHoliday_WithAscensionDayDate_ReturnsTrue()
        {
            var input = new DateTime(2016, 5, 5);

            var result = HolidayEvaluator.IsHoliday(_country, input);

            Assert.IsTrue(result);
        }
    }
}
