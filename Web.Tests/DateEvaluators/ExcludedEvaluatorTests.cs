using System;
using Core.DateEvaluators;
using Core.Services;
using NUnit.Framework;
using Tests.Common;

namespace Web.Tests.DateEvaluators
{
    public class ExcludedEvaluatorTests : MockContainer
    {
        [Test]
        public void IsExcluded_WithExcludedDate_ReturnsTrue()
        {
            const int currentYear = 1;
            var input = new DateTime(currentYear, 1, 1);

            GetMock<ITimeService>().Setup(o => o.GetCurrentYear()).Returns(currentYear);

            var sut = GetSut();
            var result = sut.IsExcluded(input);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsExcluded_WithNonExcludedDate_ReturnsFalse()
        {
            const int currentYear = 1;
            var input = new DateTime(currentYear, 1, 2);

            GetMock<ITimeService>().Setup(o => o.GetCurrentYear()).Returns(currentYear);

            var sut = GetSut();
            var result = sut.IsExcluded(input);

            Assert.IsFalse(result);
        }

        private ExcludedEvaluator GetSut()
        {
            return new ExcludedEvaluator(
                GetMock<ITimeService>().Object);
        }
    }
}
