using System;
using Core.UseCases;
using NUnit.Framework;
using Tests.Common;

namespace Core.Tests.UseCases
{
    public class ShowPayDayTests : MockContainer
    {
        [Test]
        public void Execute_TodayIsPayDay_ResultIsCorrect()
        {
            const string expectedMessage = "YES!!1!";
            var time = new DateTime(2000, 1, 25, 12, 0, 0, DateTimeKind.Utc);
            var request = new ShowPayDay.Request(25, null, null, "UTC", time);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.IsTrue(result.IsPayDay);
            Assert.AreEqual(expectedMessage, result.Message);
        }
        
        [Test]
        public void Execute_TodayIsNotPayDay_ResultIsCorrect()
        {
            const string expectedMessage = "No =(";
            var time = new DateTime(2000, 1, 24, 12, 0, 0, DateTimeKind.Utc);
            var request = new ShowPayDay.Request(25, null, null, "UTC", time);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.IsFalse(result.IsPayDay);
            Assert.AreEqual(expectedMessage, result.Message);
        }

        [Test]
        public void Execute_UserTimeIsSet()
        {
            var time = new DateTime(2000, 1, 1, 12, 0, 0, DateTimeKind.Utc);
            var request = new ShowPayDay.Request(25, null, null, "UTC", time);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.AreEqual(time, result.UserTime);
        }

        private ShowPayDay GetSut()
        {
            return new ShowPayDay();
        }
    }
}
