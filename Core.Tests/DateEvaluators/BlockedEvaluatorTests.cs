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
        private readonly Country _country = new CountryInTest();

        [Test]
        public void IsBlocked_WithWeekDayThatIsNotExcluded_ReturnsFalse()
        {
            var notBlockedDate = new DateTime(2015, 1, 2);

            var result = BlockedEvaluator.IsBlocked(_country, notBlockedDate);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsBlocked_WithWeekDayThatIsExcluded_ReturnsTrue()   
        {
            var excludedDate = new DateTime(2015, 1, 1);

            var result = BlockedEvaluator.IsBlocked(_country, excludedDate);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsBlocked_WithWeekendDayThatIsNotExcluded_ReturnsTrue()
        {
            var weekendDate = new DateTime(2015, 1, 3);

            var result = BlockedEvaluator.IsBlocked(_country, weekendDate);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsBlocked_WithWeekendDayThatIsExcluded_ReturnsTrue()
        {
            var blockedWeekendDate = new DateTime(2015, 6, 6);

            var result = BlockedEvaluator.IsBlocked(_country, blockedWeekendDate);

            Assert.IsTrue(result);
        }
    }
}
