using System;
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
        public void PayDayString_IsSetFromUseCase()
        {
            var activeForm = It.IsAny<string>();
            const string message = "a";
            var interactorResult = new ShowPayDayResultInTest(message: message);

            var sut = GetSut();
            var result = sut.Build(interactorResult, activeForm);

            Assert.AreEqual(message, result.PayDayString);
        }

        [Test]
        public void LocalTime_IsSetFromUseCase()
        {
            var activeForm = It.IsAny<string>();
            const string expected = "Sat, 01 Jan 2000 00:00:00 GMT";
            var time = new DateTime(2000, 1, 1);
            var interactorResult = new ShowPayDayResultInTest(userTime: time);

            var sut = GetSut();
            var result = sut.Build(interactorResult, activeForm);

            Assert.AreEqual(expected, result.LocalTime);
        }

        [Test]
        public void GoogleAnalyticsModel_IsCreatedFromFactory()
        {
            var activeForm = It.IsAny<string>();

            GetMock<IGoogleAnalyticsModelFactory>().Setup(o => o.Create()).Returns(new GoogleAnalyticsModel());

            var sut = GetSut();
            var result = sut.Build(new ShowPayDayResultInTest(), activeForm);

            Assert.NotNull(result.GoogleAnalyticsModel);
        }

        [Test]
        public void SettingsFormModel_IsSet()
        {
            var activeForm = It.IsAny<string>();

            GetMock<ISettingsFormModelFactory>().Setup(o => o.Create(activeForm)).Returns(new SettingsFormModel());

            var sut = GetSut();
            var result = sut.Build(new ShowPayDayResultInTest(), activeForm);

            Assert.IsInstanceOf<SettingsFormModel>(result.SettingsFormModel);
        }

        private PageBuilder GetSut()
        {
            return new PageBuilder(
                GetMock<IGoogleAnalyticsModelFactory>().Object,
                GetMock<ISettingsFormModelFactory>().Object);
        }
    }
}
