using System;
using Core.Classes;
using Core.DateEvaluators;  
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;

namespace Core.Tests.DateEvaluators
{
    public class BlockedEvaluatorTests : MockContainer
    {
        private readonly Country _defaultCountry = new CountryInTest();
        private readonly Country _sweden = new CountryInTest(CountryCode.Sweden);

        [Test]
        public void IsBlocked_WithWeekDayThatIsNotExcluded_ReturnsFalse()
        {
            var notBlockedDate = new DateTime(2015, 1, 2);

            var result = BlockedEvaluator.IsBlocked(_defaultCountry, notBlockedDate);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsBlocked_WithWeekDayThatIsHoliday_ReturnsTrue()   
        {
            var excludedDate = new DateTime(2015, 1, 1);

            var result = BlockedEvaluator.IsBlocked(_sweden, excludedDate);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsBlocked_WithWeekendDayThatIsNotExcluded_ReturnsTrue()
        {
            var weekendDate = new DateTime(2015, 1, 3);

            var result = BlockedEvaluator.IsBlocked(_defaultCountry, weekendDate);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsBlocked_WithWeekendDayThatIsExcluded_ReturnsTrue()
        {
            var blockedWeekendDate = new DateTime(2015, 6, 6);

            var result = BlockedEvaluator.IsBlocked(_defaultCountry, blockedWeekendDate);

            Assert.IsTrue(result);
        }
    }
}
