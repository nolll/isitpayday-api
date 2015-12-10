using System;
using Core.DateEvaluators;
using Core.Services;
using NUnit.Framework;
using Tests.Common;

namespace Core.Tests.DateEvaluators
{
    public class ExcludedEvaluatorTests : MockContainer
    {
        [Test]
        public void IsExcluded_WithExcludedDate_ReturnsTrue()
        {
            const int currentYear = 1;
            var input = new DateTime(currentYear, 1, 1);

            GetMock<ITimeService>().Setup(o => o.GetCurrentYear()).Returns(currentYear);

            var result = ExcludedEvaluator.IsExcluded(input);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsExcluded_WithNonExcludedDate_ReturnsFalse()
        {
            const int currentYear = 1;
            var input = new DateTime(currentYear, 1, 2);

            GetMock<ITimeService>().Setup(o => o.GetCurrentYear()).Returns(currentYear);

            var result = ExcludedEvaluator.IsExcluded(input);

            Assert.IsFalse(result);
        }
    }
}
