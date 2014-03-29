using System;
using System.Collections.Generic;
using System.Linq;
using Core.Classes;
using Core.Services;
using Core.UseCases;
using Moq;
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;
using Web.ModelFactories;

namespace Web.Tests.ModelFactories
{
    public class SettingsFormModelFactoryTests : MockContainer
    {
        [Test]
        public void PayDay_WithPayDay_IsSetFromSelectedPayDay()
        {
            var activeForm = It.IsAny<string>();
            const int selectedPayDay = 1;
            var showSettingsResult = new ShowSettingsResult(selectedPayDay, new CountryInTest(), TimeZoneInfo.Utc, PayDayType.Monthly, new List<int>(), new List<PayDayType>(), new List<Country>(), new List<TimeZoneInfo>());

            GetMock<IShowSettings>().Setup(o => o.Execute()).Returns(showSettingsResult);

            var sut = GetSut();
            var result = sut.Create(activeForm);

            Assert.AreEqual(selectedPayDay, result.PayDay);
        }

        [Test]
        public void Timezone_WithTimezone_NameAndIdIsSet()
        {
            var activeForm = It.IsAny<string>();
            const string expectedTimeZoneId = "UTC";
            const string expectedTimeZoneName = "UTC";
            var showSettingsResult = new ShowSettingsResult(It.IsAny<int>(), new CountryInTest(), TimeZoneInfo.Utc, PayDayType.Monthly, new List<int>(), new List<PayDayType>(), new List<Country>(), new List<TimeZoneInfo>());

            GetMock<IShowSettings>().Setup(o => o.Execute()).Returns(showSettingsResult);
            
            var sut = GetSut();
            var result = sut.Create(activeForm);

            Assert.AreEqual(expectedTimeZoneId, result.TimeZoneId);
            Assert.AreEqual(expectedTimeZoneName, result.TimeZoneName);
        }

        [Test]
        public void ActiveForms_WithCountryForm_OnlyCountryFormIsShown()
        {
            const string activeForm = "country";
            var showSettingsResult = new ShowSettingsResult(It.IsAny<int>(), new CountryInTest(), TimeZoneInfo.Utc, PayDayType.Monthly, new List<int>(), new List<PayDayType>(), new List<Country>(), new List<TimeZoneInfo>());

            GetMock<IShowSettings>().Setup(o => o.Execute()).Returns(showSettingsResult);
            
            var sut = GetSut();
            var result = sut.Create(activeForm);

            Assert.IsTrue(result.ShowCountryForm);
            Assert.IsFalse(result.ShowTimeZoneForm);
            Assert.IsFalse(result.ShowPayDayForm);
        }

        [Test]
        public void ActiveForms_WithTimeZoneForm_OnlyTimeZoneFormIsShown()
        {
            const string activeForm = "timezone";
            var showSettingsResult = new ShowSettingsResult(It.IsAny<int>(), new CountryInTest(), TimeZoneInfo.Utc, PayDayType.Monthly, new List<int>(), new List<PayDayType>(), new List<Country>(), new List<TimeZoneInfo>());

            GetMock<IShowSettings>().Setup(o => o.Execute()).Returns(showSettingsResult);
            
            var sut = GetSut();
            var result = sut.Create(activeForm);

            Assert.IsFalse(result.ShowCountryForm);
            Assert.IsTrue(result.ShowTimeZoneForm);
            Assert.IsFalse(result.ShowPayDayForm);
        }

        [Test]
        public void ActiveForms_WithPayDayForm_OnlyPayDayFormIsShown()
        {
            const string activeForm = "payday";
            var showSettingsResult = new ShowSettingsResult(It.IsAny<int>(), new CountryInTest(), TimeZoneInfo.Utc, PayDayType.Monthly, new List<int>(), new List<PayDayType>(), new List<Country>(), new List<TimeZoneInfo>());

            GetMock<IShowSettings>().Setup(o => o.Execute()).Returns(showSettingsResult);
            
            var sut = GetSut();
            var result = sut.Create(activeForm);

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
            var showSettingsResult = new ShowSettingsResult(It.IsAny<int>(), country, TimeZoneInfo.Utc, PayDayType.Monthly, new List<int>(), new List<PayDayType>(), new List<Country>(), new List<TimeZoneInfo>());

            GetMock<IShowSettings>().Setup(o => o.Execute()).Returns(showSettingsResult);
            
            var sut = GetSut();
            var result = sut.Create(activeForm);

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
            var showSettingsResult = new ShowSettingsResult(It.IsAny<int>(), new CountryInTest(), TimeZoneInfo.Utc, PayDayType.Monthly, new List<int>(), new List<PayDayType>(), countryList, new List<TimeZoneInfo>());

            GetMock<IShowSettings>().Setup(o => o.Execute()).Returns(showSettingsResult);

            var sut = GetSut();
            var result = sut.Create(activeForm);

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
            var showSettingsResult = new ShowSettingsResult(It.IsAny<int>(), new CountryInTest(), TimeZoneInfo.Utc, PayDayType.Monthly, new List<int>(), new List<PayDayType>(), new List<Country>(), timeZoneList);

            GetMock<IShowSettings>().Setup(o => o.Execute()).Returns(showSettingsResult);
            GetMock<ITimeService>().Setup(o => o.GetTimezones()).Returns(timeZoneList);

            var sut = GetSut();
            var result = sut.Create(activeForm);

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
            var showSettingsResult = new ShowSettingsResult(It.IsAny<int>(), new CountryInTest(), TimeZoneInfo.Utc, PayDayType.Monthly, payDayOptions, new List<PayDayType>(), new List<Country>(), new List<TimeZoneInfo>());

            GetMock<IShowSettings>().Setup(o => o.Execute()).Returns(showSettingsResult);
            
            var sut = GetSut();
            var result = sut.Create(activeForm);

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
            var showSettingsResult = new ShowSettingsResult(It.IsAny<int>(), new CountryInTest(), TimeZoneInfo.Utc, PayDayType.Monthly, new List<int>(), payDayTypes, new List<Country>(), new List<TimeZoneInfo>());

            GetMock<IShowSettings>().Setup(o => o.Execute()).Returns(showSettingsResult);
            
            var sut = GetSut();
            var result = sut.Create(activeForm);

            Assert.AreEqual(expectedLength, result.PayDayTypeItems.Count);
            Assert.AreEqual(firstValue, result.PayDayTypeItems.First().Value);
            Assert.AreEqual(firstText, result.PayDayTypeItems.First().Text);
        }

        private SettingsFormModelFactory GetSut()
        {
            return new SettingsFormModelFactory(
                GetMock<IShowSettings>().Object);
        }
    }
}