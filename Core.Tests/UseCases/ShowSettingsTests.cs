using System;
using System.Collections.Generic;
using Core.Classes;
using Core.Services;
using Core.UseCases;
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;
using System.Linq;

namespace Core.Tests.UseCases
{
    public class ShowSettingsTests : MockContainer
    {
        [TestCase("a")]
        [TestCase("b")]
        public void Execute_ResultContainsSelectedCountry(string countryId)
        {
            var country = new CountryInTest(id: countryId);
            var userSettings = new UserSettingsInTest(country: country);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);

            var sut = GetSut();
            var result = sut.Execute();

            Assert.AreEqual(country, result.Country);
        }

        [TestCase("UTC")]
        [TestCase("W. Europe Standard Time")]
        public void Execute_ResultContainsSelectedTimeZone(string timeZoneId)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var userSettings = new UserSettingsInTest(timeZone: timeZone);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);

            var sut = GetSut();
            var result = sut.Execute();

            Assert.AreEqual(timeZone, result.TimeZone);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Execute_ResultContainsSelectedPayDay(int payDay)
        {
            var userSettings = new UserSettingsInTest(payDay: payDay);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);

            var sut = GetSut();
            var result = sut.Execute();

            Assert.AreEqual(payDay, result.PayDay);
        }

        [TestCase(PayDayType.Weekly)]
        [TestCase(PayDayType.Monthly)]
        public void Execute_ResultContainsSelectedPayDayType(PayDayType payDayType)
        {
            var userSettings = new UserSettingsInTest(payDayType: payDayType);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);

            var sut = GetSut();
            var result = sut.Execute();

            Assert.AreEqual(payDayType, result.PayDayType);
        }

        [Test]
        public void Execute_ResultContainsCorrectPayDayTypeOptions()
        {
            var userSettings = new UserSettingsInTest();

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);

            const int expectedCount = 2;
            const PayDayType expectedFirstOption = PayDayType.Monthly;
            const PayDayType expectedLastOption = PayDayType.Weekly;

            var sut = GetSut();
            var result = sut.Execute();

            Assert.AreEqual(expectedCount, result.PayDayTypeOptions.Count);
            Assert.AreEqual(expectedFirstOption, result.PayDayTypeOptions.First());
            Assert.AreEqual(expectedLastOption, result.PayDayTypeOptions.Last());
        }

        [Test]
        public void Execute_ResultContainsCorrectPayDayOptions()
        {
            var userSettings = new UserSettingsInTest();

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);

            const int expectedCount = 31;
            const int expectedFirstOption = 1;
            const int expectedLastOption = 31;

            var sut = GetSut();
            var result = sut.Execute();

            Assert.AreEqual(expectedCount, result.PayDayOptions.Count);
            Assert.AreEqual(expectedFirstOption, result.PayDayOptions.First());
            Assert.AreEqual(expectedLastOption, result.PayDayOptions.Last());
        }

        [Test]
        public void Execute_ResultContainsCorrectCountryOptions()
        {
            const string countryId = "a";
            var countries = new List<Country> { new CountryInTest(countryId) };
            var userSettings = new UserSettingsInTest();

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<ICountryService>().Setup(o => o.GetCountries()).Returns(countries);

            var sut = GetSut();
            var result = sut.Execute();

            Assert.AreEqual(countries, result.CountryOptions);
        }

        [Test]
        public void Execute_ResultContainsCorrectTimeZoneOptions()
        {
            var timeZones = new List<TimeZoneInfo> { TimeZoneInfo.Utc };
            var userSettings = new UserSettingsInTest();

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<ITimeService>().Setup(o => o.GetTimezones()).Returns(timeZones);

            var sut = GetSut();
            var result = sut.Execute();

            Assert.AreEqual(timeZones, result.TimeZoneOptions);
        }

        private ShowSettings GetSut()
        {
            return new ShowSettings(
                GetMock<IUserSettingsService>().Object,
                GetMock<ICountryService>().Object,
                GetMock<ITimeService>().Object);
        }
    }
}
