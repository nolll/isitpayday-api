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
            const Frequency expectedFirstOption = Frequency.Monthly;
            const Frequency expectedLastOption = Frequency.Weekly;

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.AreEqual(expectedCount, result.FrequencyOptions.Count);
            Assert.AreEqual(expectedFirstOption, result.FrequencyOptions.First());
            Assert.AreEqual(expectedLastOption, result.FrequencyOptions.Last());
        }

        [Test]
        public void Execute_ResultContainsCorrectPayDayOptions()
        {
            var request = new ShowSettings.Request(null, null, null, null);

            const int expectedCount = 31;
            const int expectedFirstOption = 1;
            const int expectedLastOption = 31;

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.AreEqual(expectedCount, result.PayDayOptions.Count);
            Assert.AreEqual(expectedFirstOption, result.PayDayOptions.First());
            Assert.AreEqual(expectedLastOption, result.PayDayOptions.Last());
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
