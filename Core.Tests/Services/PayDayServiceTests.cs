using System;
using Core.DateEvaluators;
using Core.Services;
using Core.Storage;
using Moq;
using NUnit.Framework;
using Tests.Common;

namespace Core.Tests.Services
{
    public class PayDayServiceTests : MockContainer
    {
        [Test]
        public void GetSelectedPayDay_WithoutSavedPayDay_ReturnsDefaultPayDay()
        {
            const int expected = 25;

            var sut = GetSut();
            var result = sut.GetSelectedPayDay();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSelectedPayDay_WithoutPayDay_ReturnsPayDayFromStorage()
        {
            const int savedPayDay = 1;

            GetMock<IStorage>().Setup(o => o.GetPayDay()).Returns(savedPayDay);

            var sut = GetSut();
            var result = sut.GetSelectedPayDay();

            Assert.AreEqual(savedPayDay, result);
        }

        [Test]
        public void IsPayDay_TestedPayDayEqualsActualPayDay_ReturnsTrue()
        {
            var selectedPayDay = It.IsAny<int>();
            var testedPayDay = new DateTime(2000, 1, 25);
            var actualPayDay = new DateTime(2000, 1, 25);

            GetMock<IPayDayEvaluator>().Setup(o => o.GetActualPayDay(testedPayDay, selectedPayDay)).Returns(actualPayDay);

            var sut = GetSut();
            var result = sut.IsPayDay(testedPayDay, selectedPayDay);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsPayDay_TestedPayDayDoesNotEqualActualPayDay_ReturnsFalse()
        {
            var selectedPayDay = It.IsAny<int>();
            var testedPayDay = new DateTime(2000, 1, 25);
            var actualPayDay = new DateTime(2000, 1, 24);

            GetMock<IPayDayEvaluator>().Setup(o => o.GetActualPayDay(testedPayDay, selectedPayDay)).Returns(actualPayDay);

            var sut = GetSut();
            var result = sut.IsPayDay(testedPayDay, selectedPayDay);

            Assert.IsFalse(result);
        }

        private PayDayService GetSut()
        {
            return new PayDayService(
                GetMock<IStorage>().Object,
                GetMock<IPayDayEvaluator>().Object,
                GetMock<ITimeService>().Object);
        }
    }
}
