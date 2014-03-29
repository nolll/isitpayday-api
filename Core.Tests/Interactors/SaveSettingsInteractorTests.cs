using Core.Storage;
using Core.UseCases;
using Moq;
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;

namespace Core.Tests.Interactors
{
    public class SaveSettingsInteractorTests : MockContainer
    {
        [Test]
        public void Execute_WithCountryId_SavesCountry()
        {
            const string countryId = "a";
            var request = new SaveSettingsRequestInTest(countryId: countryId);

            var sut = GetSut();
            sut.Execute(request);

            GetMock<IStorage>().Verify(o => o.SetCountry(countryId));
        }

        [Test]
        public void Execute_WithoutCountryId_DoesntSaveCountry()
        {
            var request = new SaveSettingsRequestInTest();

            var sut = GetSut();
            sut.Execute(request);

            GetMock<IStorage>().Verify(o => o.SetCountry(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Execute_WithTimeZoneId_SavesTimeZone()
        {
            const string timeZoneId = "a";
            var request = new SaveSettingsRequestInTest(timeZoneId: timeZoneId);

            var sut = GetSut();
            sut.Execute(request);

            GetMock<IStorage>().Verify(o => o.SetTimeZone(timeZoneId));
        }

        [Test]
        public void Execute_WithoutTimeZoneId_DoesntSaveTimeZone()
        {
            var request = new SaveSettingsRequestInTest();

            var sut = GetSut();
            sut.Execute(request);

            GetMock<IStorage>().Verify(o => o.SetTimeZone(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Execute_WithPayDay_SavesTimeZone()
        {
            const int payDay = 1;
            var request = new SaveSettingsRequestInTest(payDay: payDay);

            var sut = GetSut();
            sut.Execute(request);

            GetMock<IStorage>().Verify(o => o.SetPayDay(payDay));
        }

        [Test]
        public void Execute_WithoutPayDay_DoesntSavePayDay()
        {
            var request = new SaveSettingsRequestInTest();

            var sut = GetSut();
            sut.Execute(request);

            GetMock<IStorage>().Verify(o => o.SetPayDay(It.IsAny<int>()), Times.Never);
        }

        private SaveSettings GetSut()
        {
            return new SaveSettings(
                GetMock<IStorage>().Object);
        }
    }
}
