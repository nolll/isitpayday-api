using System;
using Core.DateEvaluators;
using NUnit.Framework;
using Tests.Common;

namespace Web.Tests.DateEvaluators
{
    public class PayDayEvaluatorTests : MockContainer
    {
        [Test]
        public void GetActualPayDay_WithAllowedDate_ReturnsThatDate()
        {
            var date = new DateTime(2000, 1, 25);
            const int payDay = 25;
            var expectedDate = date;

            var sut = GetSut();
            var result = sut.GetActualPayDay(date, payDay);

            Assert.AreEqual(expectedDate, result);
        }

        [Test]
        public void GetActualPayDay_WithBlockedDate_ReturnsThePreviousDate()
        {
            var date = new DateTime(2000, 1, 25);
            const int payDay = 25;
            var expectedDate = new DateTime(2000, 1, 24);

            GetMock<IBlockedEvaluator>().Setup(o => o.IsBlocked(date)).Returns(true);

            var sut = GetSut();
            var result = sut.GetActualPayDay(date, payDay);

            Assert.AreEqual(expectedDate, result);
        }

        [Test]
        public void GetActualPayDay_WithBlockedCurrentAndPreviousDates_ReturnsTheDateTwoDaysBefore()
        {
            var date = new DateTime(2000, 1, 25);
            var prevDate = date.AddDays(-1);
            const int payDay = 25;
            var expectedDate = new DateTime(2000, 1, 23);

            GetMock<IBlockedEvaluator>().Setup(o => o.IsBlocked(date)).Returns(true);
            GetMock<IBlockedEvaluator>().Setup(o => o.IsBlocked(prevDate)).Returns(true);

            var sut = GetSut();
            var result = sut.GetActualPayDay(date, payDay);

            Assert.AreEqual(expectedDate, result);
        }

        private PayDayEvaluator GetSut()
        {
            return new PayDayEvaluator(
                GetMock<IBlockedEvaluator>().Object);
        }
    }
}
