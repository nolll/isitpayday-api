using System;
using Core.DateEvaluators;
using Core.Services;
using Moq;
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;

namespace Core.Tests.Services
{
    public class PayDayServiceTests : MockContainer
    {
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

        [Test]
        public void IsPayDay_TodayIsPayDay_ReturnsTrue()
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            const int payDay = 1;
            var userSettings = new FakeUserSettings(timeZone: timeZone, payDay: payDay);
            var userTime = new DateTime(1, 1, 1, 1, 1, 1);
            var actualPayDay = new DateTime(1, 1, 1, 0, 0, 0);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<ITimeService>().Setup(o => o.GetTime(timeZone)).Returns(userTime);
            GetMock<IPayDayEvaluator>().Setup(o => o.GetActualPayDay(userTime, payDay)).Returns(actualPayDay);

            var sut = GetSut();
            var result = sut.IsPayDay();

            Assert.IsTrue(result);
        }

        [Test]
        public void IsPayDay_TodayIsNotPayDay_ReturnsFalse()
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            const int payDay = 2;
            var userSettings = new FakeUserSettings(timeZone: timeZone, payDay: payDay);
            var userTime = new DateTime(1, 1, 1, 1, 1, 1);
            var actualPayDay = new DateTime(1, 1, 2, 0, 0, 0);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<ITimeService>().Setup(o => o.GetTime(timeZone)).Returns(userTime);
            GetMock<IPayDayEvaluator>().Setup(o => o.GetActualPayDay(userTime, payDay)).Returns(actualPayDay);

            var sut = GetSut();
            var result = sut.IsPayDay();

            Assert.IsFalse(result);
        }

        private PayDayService GetSut()
        {
            return new PayDayService(
                GetMock<IPayDayEvaluator>().Object,
                GetMock<ITimeService>().Object,
                GetMock<IUserSettingsService>().Object);
        }
    }
}
