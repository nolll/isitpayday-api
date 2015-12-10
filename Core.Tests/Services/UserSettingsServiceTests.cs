using System;
using Core.Classes;
using Core.Services;
using Core.Storage;
using NUnit.Framework;
using Tests.Common;

namespace Core.Tests.Services
{
    public class UserSettingsServiceTests : MockContainer
    {
        [Test]
        public void GetSettings_WithoutSavedCountry_ReturnsSweden()
        {
            const string expected = "Sweden";

            var sut = GetSut();
            var result = sut.GetSettings();

            Assert.AreEqual(expected, result.Country.Name);
        }

        [Test]
        public void GetSettings_WithSavedCountry_ReturnsThatCountry()
        {
            const string expected = "Norway";

            GetMock<IStorage>().Setup(o => o.GetCountry()).Returns("NO");

            var sut = GetSut();
            var result = sut.GetSettings();

            Assert.AreEqual(expected, result.Country.Name);
        }

        [Test]
        public void GetSettings_WithoutSavedTimeZone_ReturnsThatTimeZone()
        {
            var utc = TimeZoneInfo.Utc;
            var westernEurope = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");

            var sut = GetSut();
            var result = sut.GetSettings();

            Assert.AreEqual(westernEurope, result.TimeZone);
        }

        [Test]
        public void GetSettings_WithSavedTimeZone_ReturnsThatTimeZone()
        {
            var utc = TimeZoneInfo.Utc;

            GetMock<IStorage>().Setup(o => o.GetTimeZone()).Returns("UTC");

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
            return new UserSettingsService(GetMock<IStorage>().Object);
        }
    }
}
