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
            var date = It.IsAny<DateTime>();

            GetMock<IExcludedEvaluator>().Setup(o => o.IsExcluded(date)).Returns(false);
            GetMock<IWeekendEvaluator>().Setup(o => o.IsWeekend(date)).Returns(false);

            var sut = GetSut();
            var result = sut.IsBlocked(date);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsBlocked_WithWeekDayThatIsExcluded_ReturnsTrue()
        {
            var date = It.IsAny<DateTime>();

            GetMock<IExcludedEvaluator>().Setup(o => o.IsExcluded(date)).Returns(true);
            GetMock<IWeekendEvaluator>().Setup(o => o.IsWeekend(date)).Returns(false);

            var sut = GetSut();
            var result = sut.IsBlocked(date);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsBlocked_WithWeekendDayThatIsNotExcluded_ReturnsTrue()
        {
            var date = It.IsAny<DateTime>();

            GetMock<IExcludedEvaluator>().Setup(o => o.IsExcluded(date)).Returns(false);
            GetMock<IWeekendEvaluator>().Setup(o => o.IsWeekend(date)).Returns(true);

            var sut = GetSut();
            var result = sut.IsBlocked(date);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsBlocked_WithWeekendDayThatIsExcluded_ReturnsTrue()
        {
            var date = It.IsAny<DateTime>();

            GetMock<IExcludedEvaluator>().Setup(o => o.IsExcluded(date)).Returns(true);
            GetMock<IWeekendEvaluator>().Setup(o => o.IsWeekend(date)).Returns(true);

            var sut = GetSut();
            var result = sut.IsBlocked(date);

            Assert.IsTrue(result);
        }

        private BlockedEvaluator GetSut()
        {
            return new BlockedEvaluator(
                GetMock<IWeekendEvaluator>().Object,
                GetMock<IExcludedEvaluator>().Object);
        }
    }
}
