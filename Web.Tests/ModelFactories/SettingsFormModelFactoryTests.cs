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
        public void PayDay_WithMonthlyPayDay_IsSetFromSelectedPayDay()
        {
            var activeForm = It.IsAny<string>();
            const int selectedPayDay = 1;
            const string expected = "1st";
            var showSettingsResult = GetShowSettingsResult(selectedPayDay, frequency: Frequency.Monthly);

            var result = new SettingsFormModel(showSettingsResult, activeForm);

            Assert.AreEqual(expected, result.PayDay);
        }

        [Test]
        public void PayDay_WithPayDay_IsSetFromSelectedPayDay()
        {
            var activeForm = It.IsAny<string>();
            const int selectedPayDay = 1;
            const string expected = "Monday";
            var showSettingsResult = GetShowSettingsResult(selectedPayDay, frequency: Frequency.Weekly);

            var result = new SettingsFormModel(showSettingsResult, activeForm);

            Assert.AreEqual(expected, result.PayDay);
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
            const string expectedText = "1st";
            const string expectedValue = "1";
            const int expectedLength = 1;
            var payDayOptions = new List<int> {firstValue};
            var showSettingsResult = GetShowSettingsResult(monthlyPayDayOptions: payDayOptions);

            var result = new SettingsFormModel(showSettingsResult, activeForm);

            Assert.AreEqual(expectedLength, result.PayDayItems.Count);
            Assert.AreEqual(expectedValue, result.PayDayItems.First().Value);
            Assert.AreEqual(expectedText, result.PayDayItems.First().Text);
        }

        [Test]
        public void FrequencyItems_ContainsCorrectItems()
        {
            var activeForm = It.IsAny<string>();
            var frequencies = new List<Frequency> {Frequency.Monthly};
            const string firstValue = "1";
            const string firstText = "Monthly";
            const int expectedLength = 1;
            var showSettingsResult = GetShowSettingsResult(frequencyOptions: frequencies);

            var result = new SettingsFormModel(showSettingsResult, activeForm);

            Assert.AreEqual(expectedLength, result.FrequencyItems.Count);
            Assert.AreEqual(firstValue, result.FrequencyItems.First().Value);
            Assert.AreEqual(firstText, result.FrequencyItems.First().Text);
        }

        private static ShowSettings.Result GetShowSettingsResult(
            int? payDay = null,
            Country country = null,
            TimeZoneInfo timeZone = null,
            Frequency? frequency = null,
            IList<int> monthlyPayDayOptions = null,
            IList<Weekday> weeklyPayDayOptions = null,
            IList<Frequency> frequencyOptions = null,
            IList<Country> countryOptions = null,
            IList<TimeZoneInfo> timeZoneOptions = null)
        {
            return new ShowSettings.Result(
                payDay ?? It.IsAny<int>(),
                country ?? new CountryInTest(),
                timeZone ?? TimeZoneInfo.Utc,
                frequency ?? Frequency.Monthly,
                monthlyPayDayOptions ?? new List<int>(),
                weeklyPayDayOptions ?? new List<Weekday>(),
                frequencyOptions ?? new List<Frequency>(),
                countryOptions ?? new List<Country>(),
                timeZoneOptions ?? new List<TimeZoneInfo>());
        }
    }
}