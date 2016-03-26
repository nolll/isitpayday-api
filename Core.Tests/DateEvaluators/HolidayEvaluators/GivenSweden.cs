using System;
using Core.DateEvaluators;
using NUnit.Framework;

namespace Core.Tests.DateEvaluators.HolidayEvaluators
{
    public class GivenSweden : Arrange
    {
        protected override string CountryCode => "SE";

        [Test]
        public void NewYearsDayIsHoliday() => Assert.IsTrue(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 1, 1)));

        [Test]
        public void EpiphanyIsHoliday() => Assert.IsTrue(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 1, 6)));

        [Test]
        public void GoodFridayIsHoliday() => Assert.IsTrue(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 3, 25)));

        [Test]
        public void EasterMondayIsHoliday() => Assert.IsTrue(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 3, 25)));

        [Test]
        public void AscensionDayIsHoliday() => Assert.IsTrue(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 5, 5)));

        [Test]
        public void ChristmasEveIsHoliday() => Assert.IsTrue(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 12, 24)));

        [Test]
        public void ChristmasDayIsHoliday() => Assert.IsTrue(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 12, 25)));

        [Test]
        public void NewYearsEveIsHoliday() => Assert.IsTrue(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 12, 31)));

        [Test]
        public void AnyOtherDayIsNotHoliday() => Assert.IsFalse(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 1, 2)));
    }
}