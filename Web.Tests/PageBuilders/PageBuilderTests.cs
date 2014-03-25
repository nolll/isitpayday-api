using System;
using System.Collections.Generic;
using Core.Classes;
using Core.Services;
using Core.UseCases.GetPayDay;
using Moq;
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;
using Web.ModelFactories;
using Web.Models;
using Web.PageBuilders;
using System.Linq;

namespace Web.Tests.PageBuilders
{
    public class PageBuilderTests : MockContainer
    {
        [Test]
        public void PayDayString_IsSetFromInteractor()
        {
            var activeForm = It.IsAny<string>();
            const string message = "a";
            var userSettings = new UserSettingsInTest(new CountryInTest(), TimeZoneInfo.Utc);
            var interactorResult = new ShowPayDayResultInTest(message: message);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDayInteractor>().Setup(o => o.Execute()).Returns(interactorResult);

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.AreEqual(message, result.PayDayString);
        }

        [Test]
        public void PayDay_WithPayDay_IsSetFromSelectedPayDay()
        {
            var activeForm = It.IsAny<string>();
            const int selectedPayDay = 1;
            var userSettings = new UserSettingsInTest(new CountryInTest(), TimeZoneInfo.Utc, selectedPayDay);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDayInteractor>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.AreEqual(selectedPayDay, result.PayDay);
        }

        [Test]
        public void Timezone_WithTimezone_NameAndIdIsSet()
        {
            var userSettings = new UserSettingsInTest(new CountryInTest(), TimeZoneInfo.Utc);
            var activeForm = It.IsAny<string>();
            const string expectedTimeZoneId = "UTC";
            const string expectedTimeZoneName = "UTC";

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDayInteractor>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.AreEqual(expectedTimeZoneId, result.TimeZoneId);
            Assert.AreEqual(expectedTimeZoneName, result.TimeZoneName);
        }

        [Test]
        public void ActiveForms_WithCountryForm_OnlyCountryFormIsShown()
        {
            const string activeForm = "country";
            var userSettings = new UserSettingsInTest(new CountryInTest(), TimeZoneInfo.Utc);
            
            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDayInteractor>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.IsTrue(result.ShowCountryForm);
            Assert.IsFalse(result.ShowTimeZoneForm);
            Assert.IsFalse(result.ShowPayDayForm);
        }

        [Test]
        public void ActiveForms_WithTimeZoneForm_OnlyTimeZoneFormIsShown()
        {
            const string activeForm = "timezone";
            var userSettings = new UserSettingsInTest(new CountryInTest(), TimeZoneInfo.Utc);
            
            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDayInteractor>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.IsFalse(result.ShowCountryForm);
            Assert.IsTrue(result.ShowTimeZoneForm);
            Assert.IsFalse(result.ShowPayDayForm);
        }

        [Test]
        public void ActiveForms_WithPayDayForm_OnlyPayDayFormIsShown()
        {
            const string activeForm = "payday";
            var userSettings = new UserSettingsInTest(new CountryInTest(), TimeZoneInfo.Utc);
            
            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDayInteractor>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());

            var sut = GetSut();
            var result = sut.Build(activeForm);

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
            var userSettings = new UserSettingsInTest(country, TimeZoneInfo.Utc);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDayInteractor>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.AreEqual(countryId, result.CountryId);
            Assert.AreEqual(countryName, result.CountryName);
        }

        [Test]
        public void LocalTime_IsSetFromTimeService()
        {
            var activeForm = It.IsAny<string>();
            const string expected = "Sat, 01 Jan 2000 00:00:00 GMT";
            var timeZone = TimeZoneInfo.Utc;
            var time = new DateTime(2000, 1, 1);
            var userSettings = new UserSettingsInTest(new CountryInTest(), TimeZoneInfo.Utc);

            GetMock<ITimeService>().Setup(o => o.GetTime(timeZone)).Returns(time);
            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDayInteractor>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.AreEqual(expected, result.LocalTime);
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
            var userSettings = new UserSettingsInTest(new CountryInTest(), TimeZoneInfo.Utc);

            GetMock<ICountryService>().Setup(o => o.GetCountries()).Returns(countryList);
            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDayInteractor>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());

            var sut = GetSut();
            var result = sut.Build(activeForm);

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
            var userSettings = new UserSettingsInTest(new CountryInTest(), TimeZoneInfo.Utc);

            GetMock<ITimeService>().Setup(o => o.GetTimezones()).Returns(timeZoneList);
            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDayInteractor>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.AreEqual(expectedLength, result.TimeZoneItems.Count);
            Assert.AreEqual(timeZoneId, result.TimeZoneItems[0].Value);
            Assert.AreEqual(timeZoneName, result.TimeZoneItems[0].Text);
        }

        [Test]
        public void PayDayItems_ContainsItemsFor31Days()
        {
            var activeForm = It.IsAny<string>();
            const string firstValue = "1";
            const string lastValue = "31";
            const int expectedLength = 31;
            var userSettings = new UserSettingsInTest(new CountryInTest(), TimeZoneInfo.Utc);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDayInteractor>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.AreEqual(expectedLength, result.PayDayItems.Count);
            Assert.AreEqual(firstValue, result.PayDayItems.First().Value);
            Assert.AreEqual(firstValue, result.PayDayItems.First().Text);
            Assert.AreEqual(lastValue, result.PayDayItems.Last().Value);
            Assert.AreEqual(lastValue, result.PayDayItems.Last().Text);
        }

        [Test]
        public void PayDayTypeItems_ContainsCorrectItems()
        {
            var activeForm = It.IsAny<string>();
            const string firstValue = "1";
            const string firstText = "Monthly";
            const string lastValue = "2";
            const string lastText = "Weekly";
            const int expectedLength = 2;
            var userSettings = new UserSettingsInTest(new CountryInTest(), TimeZoneInfo.Utc);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDayInteractor>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.AreEqual(expectedLength, result.PayDayTypeItems.Count);
            Assert.AreEqual(firstValue, result.PayDayTypeItems.First().Value);
            Assert.AreEqual(firstText, result.PayDayTypeItems.First().Text);
            Assert.AreEqual(lastValue, result.PayDayTypeItems.Last().Value);
            Assert.AreEqual(lastText, result.PayDayTypeItems.Last().Text);
        }

        [Test]
        public void GoogleAnalyticsModel_IsCreatedFromFactory()
        {
            var activeForm = It.IsAny<string>();
            var userSettings = new UserSettingsInTest(new CountryInTest(), TimeZoneInfo.Utc);

            GetMock<IGoogleAnalyticsModelFactory>().Setup(o => o.Create()).Returns(new GoogleAnalyticsModel());
            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDayInteractor>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.NotNull(result.GoogleAnalyticsModel);
        }

        private PageBuilder GetSut()
        {
            return new PageBuilder(
                GetMock<ITimeService>().Object,
                GetMock<ICountryService>().Object,
                GetMock<IGoogleAnalyticsModelFactory>().Object,
                GetMock<IUserSettingsService>().Object,
                GetMock<IShowPayDayInteractor>().Object);
        }
    }
}
