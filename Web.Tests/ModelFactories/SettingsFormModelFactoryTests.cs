using System;
using System.Collections.Generic;
using System.Linq;
using Core.Classes;
using Core.UseCases;
using Moq;
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;
using Web.Models;

namespace Web.Tests.ModelFactories
{
    public class SettingsFormModelFactoryTests : MockContainer
    {
        [Test]
        public void PayDay_WithPayDay_IsSetFromSelectedPayDay()
        {
            var activeForm = It.IsAny<string>();
            const int selectedPayDay = 1;
            var showSettingsResult = GetShowSettingsResult(selectedPayDay);

            var result = new SettingsFormModel(showSettingsResult, activeForm);

            Assert.AreEqual(selectedPayDay, result.PayDay);
        }

        [Test]
        public void Timezone_WithTimezone_NameAndIdIsSet()
        {
            var activeForm = It.IsAny<string>();
            const string expectedTimeZoneId = "UTC";
            const string expectedTimeZoneName = "UTC";
            var showSettingsResult = GetShowSettingsResult(timeZone: TimeZoneInfo.Utc);

            var result = new SettingsFormModel(showSettingsResult, activeForm);

            Assert.AreEqual(expectedTimeZoneId, result.TimeZoneId);
            Assert.AreEqual(expectedTimeZoneName, result.TimeZoneName);
        }

        [Test]
        public void ActiveForms_WithCountryForm_OnlyCountryFormIsShown()
        {
            const string activeForm = "country";
            var showSettingsResult = GetShowSettingsResult();

            var result = new SettingsFormModel(showSettingsResult, activeForm);

            Assert.IsTrue(result.ShowCountryForm);
            Assert.IsFalse(result.ShowTimeZoneForm);
            Assert.IsFalse(result.ShowPayDayForm);
        }

        [Test]
        public void ActiveForms_WithTimeZoneForm_OnlyTimeZoneFormIsShown()
        {
            const string activeForm = "timezone";
            var showSettingsResult = GetShowSettingsResult();

            var result = new SettingsFormModel(showSettingsResult, activeForm);

            Assert.IsFalse(result.ShowCountryForm);
            Assert.IsTrue(result.ShowTimeZoneForm);
            Assert.IsFalse(result.ShowPayDayForm);
        }

        [Test]
        public void ActiveForms_WithPayDayForm_OnlyPayDayFormIsShown()
        {
            const string activeForm = "payday";
            var showSettingsResult = GetShowSettingsResult();

            var result = new SettingsFormModel(showSettingsResult, activeForm);

            Assert.IsFalse(result.ShowCountryForm);
            Assert.IsFalse(result.ShowTimeZoneForm);
            Assert.IsTrue(result.ShowPayDayForm);
        }

        [Test]
        public void Country_WithCountry_IdAndNameIsSet()
        {
            var activeForm = It.IsAny<string>();
            const string countryId = "a";
            const string countryName = "b";
            var country = new CountryInTest(countryId, countryName);
            var showSettingsResult = GetShowSettingsResult(country: country);

            var result = new SettingsFormModel(showSettingsResult, activeForm);

            Assert.AreEqual(countryId, result.CountryId);
            Assert.AreEqual(countryName, result.CountryName);
        }

        [Test]
        public void CountryItems_WithOneCountry_ContainsCorrectItem()
        {
            var activeForm = It.IsAny<string>();
            const string countryId = "a";
            const string countryName = "b";
            const int expectedLength = 1;
            var country = new CountryInTest(countryId, countryName);
            var countryList = new List<Country> { country };
            var showSettingsResult = GetShowSettingsResult(countryOptions: countryList);

            var result = new SettingsFormModel(showSettingsResult, activeForm);

            Assert.AreEqual(expectedLength, result.CountryItems.Count);
            Assert.AreEqual(countryId, result.CountryItems[0].Value);
            Assert.AreEqual(countryName, result.CountryItems[0].Text);
        }

        [Test]
        public void TimeZoneItems_WithOneTimeZone_ContainsCorrectItem()
        {
            var activeForm = It.IsAny<string>();
            var timeZone = TimeZoneInfo.Utc;
            var timeZoneId = timeZone.Id;
            var timeZoneName = timeZone.StandardName;
            const int expectedLength = 1;
            var timeZoneList = new List<TimeZoneInfo> { timeZone };
            var showSettingsResult = GetShowSettingsResult(timeZoneOptions: timeZoneList);

            var result = new SettingsFormModel(showSettingsResult, activeForm);

            Assert.AreEqual(expectedLength, result.TimeZoneItems.Count);
            Assert.AreEqual(timeZoneId, result.TimeZoneItems[0].Value);
            Assert.AreEqual(timeZoneName, result.TimeZoneItems[0].Text);
        }

        [Test]
        public void PayDayItems_ContainsItemsFor31Days()
        {
            var activeForm = It.IsAny<string>();
            const int firstValue = 1;
            const string expected = "1";
            const int expectedLength = 1;
            var payDayOptions = new List<int> {firstValue};
            var showSettingsResult = GetShowSettingsResult(payDayOptions: payDayOptions);

            var result = new SettingsFormModel(showSettingsResult, activeForm);

            Assert.AreEqual(expectedLength, result.PayDayItems.Count);
            Assert.AreEqual(expected, result.PayDayItems.First().Value);
            Assert.AreEqual(expected, result.PayDayItems.First().Text);
        }

        [Test]
        public void PayDayTypeItems_ContainsCorrectItems()
        {
            var activeForm = It.IsAny<string>();
            var payDayTypes = new List<PayDayType> {PayDayType.Monthly};
            const string firstValue = "1";
            const string firstText = "Monthly";
            const int expectedLength = 1;
            var showSettingsResult = GetShowSettingsResult(payDayTypeOptions: payDayTypes);

            var result = new SettingsFormModel(showSettingsResult, activeForm);

            Assert.AreEqual(expectedLength, result.PayDayTypeItems.Count);
            Assert.AreEqual(firstValue, result.PayDayTypeItems.First().Value);
            Assert.AreEqual(firstText, result.PayDayTypeItems.First().Text);
        }

        private static ShowSettings.Result GetShowSettingsResult(
            int? payDay = null,
            Country country = null,
            TimeZoneInfo timeZone = null,
            PayDayType? payDayType = null,
            IList<int> payDayOptions = null,
            IList<PayDayType> payDayTypeOptions = null,
            IList<Country> countryOptions = null,
            IList<TimeZoneInfo> timeZoneOptions = null)
        {
            return new ShowSettings.Result(
                payDay ?? It.IsAny<int>(),
                country ?? new CountryInTest(),
                timeZone ?? TimeZoneInfo.Utc,
                payDayType ?? PayDayType.Monthly,
                payDayOptions ?? new List<int>(),
                payDayTypeOptions ?? new List<PayDayType>(),
                countryOptions ?? new List<Country>(),
                timeZoneOptions ?? new List<TimeZoneInfo>());
        }
    }
}