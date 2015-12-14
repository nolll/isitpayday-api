using System;
using Core.Classes;
using Core.UseCases;
using NUnit.Framework;
using Tests.Common;
using System.Linq;

namespace Core.Tests.UseCases
{
    public class ShowSettingsTests : MockContainer
    {
        [TestCase("SE", "Sweden")]
        [TestCase("NO", "Norway")]
        public void Execute_ResultContainsSelectedCountry(string countryId, string countryName)
        {
            var request = new ShowSettings.Request(null, null, countryId, null);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.AreEqual(countryId, result.Country.Id);
            Assert.AreEqual(countryName, result.Country.Name);
        }

        [TestCase("UTC")]
        [TestCase("W. Europe Standard Time")]
        public void Execute_ResultContainsSelectedTimeZone(string timeZoneId)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var request = new ShowSettings.Request(null, null, null, timeZoneId);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.AreEqual(timeZone, result.TimeZone);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Execute_ResultContainsSelectedPayDay(int payDay)
        {
            var request = new ShowSettings.Request(payDay, null, null, null);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.AreEqual(payDay, result.PayDay);
        }

        [TestCase(1, Frequency.Monthly)]
        [TestCase(2, Frequency.Weekly)]
        public void Execute_ResultContainsSelectedFrequency(int intFrequency, Frequency enumFrequency)
        {
            var request = new ShowSettings.Request(null, intFrequency, null, null);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.AreEqual(enumFrequency, result.Frequency);
        }

        [Test]
        public void Execute_ResultContainsCorrectFrequencyOptions()
        {
            var request = new ShowSettings.Request(null, null, null, null);

            const int expectedCount = 2;
            const Frequency expectedFirstOption = Frequency.Weekly;
            const Frequency expectedLastOption = Frequency.Monthly;

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.AreEqual(expectedCount, result.FrequencyOptions.Count);
            Assert.AreEqual(expectedLastOption, result.FrequencyOptions.First());
            Assert.AreEqual(expectedFirstOption, result.FrequencyOptions.Last());
        }

        [Test]
        public void Execute_ResultContainsCorrectMonthlyPayDayOptions()
        {
            var request = new ShowSettings.Request(null, null, null, null);

            const int expectedCount = 31;
            const int expectedFirstOption = 1;
            const int expectedLastOption = 31;

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.AreEqual(expectedCount, result.MonthlyPayDayOptions.Count);
            Assert.AreEqual(expectedFirstOption, result.MonthlyPayDayOptions.First());
            Assert.AreEqual(expectedLastOption, result.MonthlyPayDayOptions.Last());
        }

        [Test]
        public void Execute_ResultContainsCorrectWeeklyPayDayOptions()
        {
            var request = new ShowSettings.Request(null, null, null, null);

            const int expectedCount = 7;

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.AreEqual(expectedCount, result.WeeklyPayDayOptions.Count);
            Assert.AreEqual(Weekday.Monday, result.WeeklyPayDayOptions[0]);
            Assert.AreEqual(Weekday.Tuesday, result.WeeklyPayDayOptions[1]);
            Assert.AreEqual(Weekday.Wednesday, result.WeeklyPayDayOptions[2]);
            Assert.AreEqual(Weekday.Thursday, result.WeeklyPayDayOptions[3]);
            Assert.AreEqual(Weekday.Friday, result.WeeklyPayDayOptions[4]);
            Assert.AreEqual(Weekday.Saturday, result.WeeklyPayDayOptions[5]);
            Assert.AreEqual(Weekday.Sunday, result.WeeklyPayDayOptions[6]);
        }

        [Test]
        public void Execute_ResultContainsCorrectCountryOptions()
        {
            const int expected = 142;
            var request = new ShowSettings.Request(null, null, null, null);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.AreEqual(expected, result.CountryOptions.Count);
        }

        [Test]
        public void Execute_ResultContainsCorrectTimeZoneOptions()
        {
            var request = new ShowSettings.Request(null, null, null, null);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.AreEqual(TimeZoneInfo.GetSystemTimeZones().Count, result.TimeZoneOptions.Count);
        }

        private ShowSettings GetSut()
        {
            return new ShowSettings();
        }
    }
}
