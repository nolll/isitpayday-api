using System;
using Core.Services;
using Core.UseCases;
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;

namespace Core.Tests.UseCases
{
    public class GetPayDayTests : MockContainer
    {
        [Test]
        public void Execute_TodayIsPayDay_ResultIsCorrect()
        {
            const string expectedMessage = "YES!!1!";
            var timeZone = TimeZoneInfo.Utc;
            var userSettings = new UserSettingsInTest(timeZone: timeZone);

            GetMock<IPayDayService>().Setup(o => o.IsPayDay()).Returns(true);
            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);

            var sut = GetSut();
            var result = sut.Execute();

            Assert.IsTrue(result.IsPayDay);
            Assert.AreEqual(expectedMessage, result.Message);
        }
        
        [Test]
        public void Execute_TodayIsNotPayDay_ResultIsCorrect()
        {
            const string expectedMessage = "No =(";
            var timeZone = TimeZoneInfo.Utc;
            var userSettings = new UserSettingsInTest(timeZone: timeZone);

            GetMock<IPayDayService>().Setup(o => o.IsPayDay()).Returns(false);
            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);

            var sut = GetSut();
            var result = sut.Execute();

            Assert.IsFalse(result.IsPayDay);
            Assert.AreEqual(expectedMessage, result.Message);
        }

        [Test]
        public void Execute_UserTimeIsSet()
        {
            var now = DateTime.Parse("2000-01-01 00:00:00");
            var timeZone = TimeZoneInfo.Utc;
            var userSettings = new UserSettingsInTest(timeZone: timeZone);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<ITimeService>().Setup(o => o.GetLocalTime(timeZone)).Returns(now);

            var sut = GetSut();
            var result = sut.Execute();

            Assert.AreEqual(now, result.UserTime);
        }

        private ShowPayDay GetSut()
        {
            return new ShowPayDay(
                GetMock<IPayDayService>().Object,
                GetMock<IUserSettingsService>().Object,
                GetMock<ITimeService>().Object);
        }
    }
}
