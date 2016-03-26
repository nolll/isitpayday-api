using System;
using Core.DateEvaluators;
using NUnit.Framework;

namespace Core.Tests.DateEvaluators.HolidayEvaluators
{
    public class GivenDefaultCountry : Arrange
    {
        [Test]
        public void NewYearsDayIsNotHoliday() => Assert.IsFalse(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 1, 1)));

        [Test]
        public void EpiphanyIsNotHoliday() => Assert.IsFalse(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 1, 6)));

        [Test]
        public void GoodFridayIsNotHoliday() => Assert.IsFalse(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 3, 25)));

        [Test]
        public void EasterMondayIsNotHoliday() => Assert.IsFalse(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 3, 25)));

        [Test]
        public void AscensionDayIsNotHoliday() => Assert.IsFalse(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 5, 5)));

        [Test]
        public void ChristmasEveIsNotHoliday() => Assert.IsFalse(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 12, 24)));

        [Test]
        public void ChristmasDayIsNotHoliday() => Assert.IsFalse(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 12, 25)));

        [Test]
        public void NewYearsEveIsNotHoliday() => Assert.IsFalse(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 12, 31)));

        [Test]
        public void AnyOtherDayIsNotHoliday() => Assert.IsFalse(HolidayEvaluator.IsHoliday(Country, new DateTime(2016, 1, 2)));
    }
}
