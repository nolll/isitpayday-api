using System;
using Core.DateEvaluators;
using NUnit.Framework;
using Tests.Common;

namespace Core.Tests.DateEvaluators
{
    public class PayDayEvaluatorTests : MockContainer
    {
        [Test]
        public void GetActualPayDay_WithAllowedDate_ReturnsThatDate()
        {
            var date = new DateTime(2015, 1, 2);
            const int payDay = 2;
            var expectedDate = date;

            var result = PayDayEvaluator.GetActualPayDay(date, payDay);

            Assert.AreEqual(expectedDate, result);
        }

        [Test]
        public void GetActualPayDay_WithBlockedDate_ReturnsThePreviousDate()
        {
            var date = new DateTime(2015, 1, 3);
            const int payDay = 3;
            var expectedDate = new DateTime(2015, 1, 2);

            var result = PayDayEvaluator.GetActualPayDay(date, payDay);

            Assert.AreEqual(expectedDate, result);
        }

        [Test]
        public void GetActualPayDay_WithBlockedCurrentAndPreviousDates_ReturnsTheDateTwoDaysBefore()
        {
            var date = new DateTime(2015, 1, 4);
            const int payDay = 4;
            var expectedDate = new DateTime(2015, 1, 2);

            var result = PayDayEvaluator.GetActualPayDay(date, payDay);

            Assert.AreEqual(expectedDate, result);
        }
    }
}
