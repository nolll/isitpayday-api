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
            var time = new DateTime(2000, 1, 25, 12, 0, 0, DateTimeKind.Utc);
            var userSettings = new UserSettingsInTest(timeZone: timeZone, payDay: 25);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<ITimeService>().Setup(o => o.GetUtcTime()).Returns(time);

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
            var time = new DateTime(2000, 1, 24, 12, 0, 0, DateTimeKind.Utc);
            var userSettings = new UserSettingsInTest(timeZone: timeZone, payDay: 25);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<ITimeService>().Setup(o => o.GetUtcTime()).Returns(time);

            var sut = GetSut();
            var result = sut.Execute();

            Assert.IsFalse(result.IsPayDay);
            Assert.AreEqual(expectedMessage, result.Message);
        }

        [Test]
        public void Execute_UserTimeIsSet()
        {
            var now = new DateTime(2000, 1, 1, 12, 0, 0, DateTimeKind.Utc);
            var timeZone = TimeZoneInfo.Utc;
            var userSettings = new UserSettingsInTest(timeZone: timeZone, payDay: 25);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<ITimeService>().Setup(o => o.GetUtcTime()).Returns(now);

            var sut = GetSut();
            var result = sut.Execute();

            Assert.AreEqual(now, result.UserTime);
        }

        private ShowPayDay GetSut()
        {
            return new ShowPayDay(
                GetMock<IUserSettingsService>().Object,
                GetMock<ITimeService>().Object);
        }
    }
}
