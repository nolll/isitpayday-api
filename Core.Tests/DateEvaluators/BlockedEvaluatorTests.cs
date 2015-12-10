using System;
using Core.DateEvaluators;
using Moq;
using NUnit.Framework;
using Tests.Common;

namespace Core.Tests.DateEvaluators
{
    public class BlockedEvaluatorTests : MockContainer
    {
        [Test]
        public void IsBlocked_WithWeekDayThatIsNotExcluded_ReturnsFalse()
        {
            var notBlockedDate = new DateTime(2015, 1, 2);

            var result = BlockedEvaluator.IsBlocked(notBlockedDate);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsBlocked_WithWeekDayThatIsExcluded_ReturnsTrue()   
        {
            var excludedDate = new DateTime(2015, 1, 1);

            var result = BlockedEvaluator.IsBlocked(excludedDate);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsBlocked_WithWeekendDayThatIsNotExcluded_ReturnsTrue()
        {
            var weekendDate = new DateTime(2015, 1, 3);

            var result = BlockedEvaluator.IsBlocked(weekendDate);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsBlocked_WithWeekendDayThatIsExcluded_ReturnsTrue()
        {
            var blockedWeekendDate = new DateTime(2015, 6, 6);

            var result = BlockedEvaluator.IsBlocked(blockedWeekendDate);

            Assert.IsTrue(result);
        }
    }
}
