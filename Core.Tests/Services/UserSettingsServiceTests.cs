using System;
using System.Collections.Generic;
using Core.Classes;
using Core.Services;
using Core.Storage;
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;

namespace Core.Tests.Services
{
    public class UserSettingsServiceTests : MockContainer
    {
        [Test]
        public void GetSettings_WithoutSavedCountry_ReturnsSweden()
        {
            var sweden = new CountryInTest("SE");
            var norway = new CountryInTest("NO");
            var countries = new List<Country> {sweden, norway};

            GetMock<ICountryService>().Setup(o => o.GetCountries()).Returns(countries);

            var sut = GetSut();
            var result = sut.GetSettings();

            Assert.AreEqual(sweden, result.Country);
        }

        [Test]
        public void GetSettings_WithSavedCountry_ReturnsThatCountry()
        {
            var sweden = new CountryInTest("SE");
            var norway = new CountryInTest("NO");
            var countries = new List<Country> { sweden, norway };

            GetMock<IStorage>().Setup(o => o.GetCountry()).Returns("NO");
            GetMock<ICountryService>().Setup(o => o.GetCountries()).Returns(countries);

            var sut = GetSut();
            var result = sut.GetSettings();

            Assert.AreEqual(norway, result.Country);
        }

        [Test]
        public void GetSettings_WithoutSavedTimeZone_ReturnsThatTimeZone()
        {
            var utc = TimeZoneInfo.Utc;
            var westernEurope = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            var timeZones = new List<TimeZoneInfo> { utc, westernEurope };

            GetMock<ITimeService>().Setup(o => o.GetTimezones()).Returns(timeZones);

            var sut = GetSut();
            var result = sut.GetSettings();

            Assert.AreEqual(westernEurope, result.TimeZone);
        }

        [Test]
        public void GetSettings_WithSavedTimeZone_ReturnsThatTimeZone()
        {
            var utc = TimeZoneInfo.Utc;
            var westernEurope = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            var timeZones = new List<TimeZoneInfo> { utc, westernEurope };

            GetMock<IStorage>().Setup(o => o.GetTimeZone()).Returns("UTC");
            GetMock<ITimeService>().Setup(o => o.GetTimezones()).Returns(timeZones);

            var sut = GetSut();
            var result = sut.GetSettings();

            Assert.AreEqual(utc, result.TimeZone);
        }

        [Test]
        public void GetSelectedPayDay_WithoutSavedPayDay_ReturnsDefaultPayDay()
        {
            const int expected = 25;

            var sut = GetSut();
            var result = sut.GetSettings();

            Assert.AreEqual(expected, result.PayDay);
        }

        [Test]
        public void GetSelectedPayDay_WithSavedPayDay_ReturnsPayDayFromStorage()
        {
            const int savedPayDay = 1;

            GetMock<IStorage>().Setup(o => o.GetPayDay()).Returns(savedPayDay);

            var sut = GetSut();
            var result = sut.GetSettings();

            Assert.AreEqual(savedPayDay, result.PayDay);
        }

        [Test]
        public void GetPayDayType_WithoutSavedType_ReturnsMonthly()
        {
            const PayDayType expected = PayDayType.Monthly;

            var sut = GetSut();
            var result = sut.GetSettings();

            Assert.AreEqual(expected, result.PayDayType);
        }

        [Test]
        public void GetPayDayType_WithMonthlySaved_ReturnsMonthly()
        {
            const int savedValue = 1;
            const PayDayType expected = PayDayType.Monthly;

            GetMock<IStorage>().Setup(o => o.GetPayDayType()).Returns(savedValue);

            var sut = GetSut();
            var result = sut.GetSettings();

            Assert.AreEqual(expected, result.PayDayType);
        }

        [Test]
        public void GetPayDayType_WithWeeklySaved_ReturnsWeekly()
        {
            const int savedValue = 2;
            const PayDayType expected = PayDayType.Weekly;

            GetMock<IStorage>().Setup(o => o.GetPayDayType()).Returns(savedValue);

            var sut = GetSut();
            var result = sut.GetSettings();

            Assert.AreEqual(expected, result.PayDayType);
        }

        private UserSettingsService GetSut()
        {
            return new UserSettingsService(
                GetMock<ICountryService>().Object,
                GetMock<ITimeService>().Object,
                GetMock<IStorage>().Object);
        }
    }
}
