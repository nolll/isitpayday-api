using System;
using Core.Classes;
using Core.DateEvaluators;
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;

namespace Core.Tests.DateEvaluators
{
    public class PayDayEvaluatorTests : MockContainer
    {
        private readonly Country _country = new CountryInTest();

        [Test]
        public void GetActualPayDay_WithAllowedDate_IsTrue()
        {
            var date = new DateTime(2015, 1, 2, 12, 0, 0, DateTimeKind.Utc);
            const int payDay = 2;

            var evaluator = PayDayEvaluator.Create(Frequency.Monthly, _country, date, TimeZoneInfo.Utc, payDay);
            var result = evaluator.IsPayDay;

            Assert.IsTrue(result);
        }

        [Test]
        public void GetActualPayDay_WithBlockedDate_ReturnsTrueForDayBefore()
        {
            var date = new DateTime(2015, 1, 2, 12, 0, 0, DateTimeKind.Utc);
            const int payDay = 3;

            var evaluator = PayDayEvaluator.Create(Frequency.Monthly, _country, date, TimeZoneInfo.Utc, payDay);
            var result = evaluator.IsPayDay;

            Assert.IsTrue(result);
        }

        [Test]
        public void GetActualPayDay_WithBlockedCurrentAndPreviousDates_ReturnsTrueForTwoDaysBefore()
        {
            var date = new DateTime(2015, 1, 2, 12, 0, 0, DateTimeKind.Utc);
            const int payDay = 4;

            var evaluator = PayDayEvaluator.Create(Frequency.Monthly, _country, date, TimeZoneInfo.Utc, payDay);
            var result = evaluator.IsPayDay;

            Assert.IsTrue(result);
        }
    }
}
