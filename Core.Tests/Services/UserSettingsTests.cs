using System;
using Core.Classes;
using Core.Services;
using NUnit.Framework;
using Tests.Common;

namespace Core.Tests.Services
{
    public class UserSettingsTests : MockContainer
    {
        [Test]
        public void GetSettings_WithoutSavedCountry_ReturnsSweden()
        {
            const string expected = "Sweden";

            var result = UserSettingsService.GetSettings(null, null, null, null);

            Assert.AreEqual(expected, result.Country.Name);
        }

        [Test]
        public void GetSettings_WithSavedCountry_ReturnsThatCountry()
        {
            const string expected = "Norway";

            var result = UserSettingsService.GetSettings(null, null, "NO", null);

            Assert.AreEqual(expected, result.Country.Name);
        }

        [Test]
        public void GetSettings_WithoutSavedTimeZone_ReturnsDefaultTimeZone()
        {
            var westernEurope = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");

            var result = UserSettingsService.GetSettings(null, null, null, null);

            Assert.AreEqual(westernEurope, result.TimeZone);
        }

        [Test]
        public void GetSettings_WithSavedTimeZone_ReturnsThatTimeZone()
        {
            var utc = TimeZoneInfo.Utc;

            var result = UserSettingsService.GetSettings(null, null, null, "UTC");

            Assert.AreEqual(utc, result.TimeZone);
        }

        [Test]
        public void GetSelectedPayDay_WithoutSavedPayDay_ReturnsDefaultPayDay()
        {
            const int expected = 25;

            var result = UserSettingsService.GetSettings(null, null, null, null);

            Assert.AreEqual(expected, result.PayDay);
        }

        [Test]
        public void GetSelectedPayDay_WithSavedPayDay_ReturnsPayDayFromStorage()
        {
            const int savedPayDay = 24;

            var result = UserSettingsService.GetSettings(savedPayDay, null, null, null);

            Assert.AreEqual(savedPayDay, result.PayDay);
        }

        [Test]
        public void GetPayDayType_WithoutSavedType_ReturnsMonthly()
        {
            const PayDayType expected = PayDayType.Monthly;

            var result = UserSettingsService.GetSettings(null, null, null, null);

            Assert.AreEqual(expected, result.PayDayType);
        }

        [Test]
        public void GetPayDayType_WithMonthlySaved_ReturnsMonthly()
        {
            const int savedValue = 1;
            const PayDayType expected = PayDayType.Monthly;

            var result = UserSettingsService.GetSettings(null, savedValue, null, null);

            Assert.AreEqual(expected, result.PayDayType);
        }

        [Test]
        public void GetPayDayType_WithWeeklySaved_ReturnsWeekly()
        {
            const int savedValue = 2;
            const PayDayType expected = PayDayType.Weekly;

            var result = UserSettingsService.GetSettings(null, savedValue, null, null);

            Assert.AreEqual(expected, result.PayDayType);
        }
    }
}
