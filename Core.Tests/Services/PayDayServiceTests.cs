﻿using System;
using Core.Services;
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
            const int selectedPayDay = 25;
            var testedPayDay = new DateTime(2000, 1, 25, 12, 0, 0);
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            var userSettings = new UserSettingsInTest(timeZone: timeZone, payDay: selectedPayDay);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            
            var sut = GetSut();
            var result = sut.IsPayDay(testedPayDay, selectedPayDay);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsPayDay_TestedPayDayDoesNotEqualActualPayDay_ReturnsFalse()
        {
            const int selectedPayDay = 25;
            var testedPayDay = new DateTime(2000, 1, 24);
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            var userSettings = new UserSettingsInTest(timeZone: timeZone, payDay: selectedPayDay);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            
            var sut = GetSut();
            var result = sut.IsPayDay(testedPayDay, selectedPayDay);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsPayDay_TodayIsPayDay_ReturnsTrue()
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            const int payDay = 23;
            var userSettings = new UserSettingsInTest(timeZone: timeZone, payDay: payDay);
            var userTime = new DateTime(2015, 1, 23, 12, 0, 0);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<ITimeService>().Setup(o => o.GetLocalTime(timeZone)).Returns(userTime);

            var sut = GetSut();
            var result = sut.IsPayDay(userTime, payDay);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsPayDay_TodayIsNotPayDay_ReturnsFalse()
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            const int payDay = 2;
            var userSettings = new UserSettingsInTest(timeZone: timeZone, payDay: payDay);
            var userTime = new DateTime(1, 1, 1, 1, 1, 1);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<ITimeService>().Setup(o => o.GetLocalTime(timeZone)).Returns(userTime);

            var sut = GetSut();
            var result = sut.IsPayDay();

            Assert.IsFalse(result);
        }

        private PayDayService GetSut()
        {
            return new PayDayService(
                GetMock<ITimeService>().Object,
                GetMock<IUserSettingsService>().Object);
        }
    }
}
