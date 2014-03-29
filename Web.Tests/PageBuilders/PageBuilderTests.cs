using System;
using Core.Services;
using Core.UseCases;
using Moq;
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;
using Web.ModelFactories;
using Web.Models;
using Web.PageBuilders;

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
            GetMock<IShowPayDay>().Setup(o => o.Execute()).Returns(interactorResult);

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.AreEqual(message, result.PayDayString);
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
            GetMock<IShowPayDay>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.AreEqual(expected, result.LocalTime);
        }

        [Test]
        public void GoogleAnalyticsModel_IsCreatedFromFactory()
        {
            var activeForm = It.IsAny<string>();
            var userSettings = new UserSettingsInTest(new CountryInTest(), TimeZoneInfo.Utc);

            GetMock<IGoogleAnalyticsModelFactory>().Setup(o => o.Create()).Returns(new GoogleAnalyticsModel());
            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDay>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.NotNull(result.GoogleAnalyticsModel);
        }

        [Test]
        public void SettingsFormModel_IsSet()
        {
            var activeForm = It.IsAny<string>();
            var userSettings = new UserSettingsInTest(new CountryInTest(), TimeZoneInfo.Utc);

            GetMock<IUserSettingsService>().Setup(o => o.GetSettings()).Returns(userSettings);
            GetMock<IShowPayDay>().Setup(o => o.Execute()).Returns(new ShowPayDayResultInTest());
            GetMock<ISettingsFormModelFactory>().Setup(o => o.Create(activeForm)).Returns(new SettingsFormModel());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.IsInstanceOf<SettingsFormModel>(result.SettingsFormModel);
        }

        private PageBuilder GetSut()
        {
            return new PageBuilder(
                GetMock<ITimeService>().Object,
                GetMock<IGoogleAnalyticsModelFactory>().Object,
                GetMock<IUserSettingsService>().Object,
                GetMock<IShowPayDay>().Object,
                GetMock<ISettingsFormModelFactory>().Object);
        }
    }
}
