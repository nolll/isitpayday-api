using Core.Classes;
using Core.Storage;
using Core.UseCases;
using Moq;
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;

namespace Core.Tests.UseCases
{
    public class SaveSettingsTests : MockContainer
    {
        [Test]
        public void Execute_WithCountryId_SavesCountry()
        {
            const string countryId = "a";
            var request = new SaveSettingsRequestInTest(newCountryId: countryId);

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
            var request = new SaveSettingsRequestInTest(newTimeZoneId: timeZoneId);

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
        public void Execute_WithPayDay_SavesPayDay()
        {
            const int payDay = 1;
            var request = new SaveSettingsRequestInTest(newPayDay: payDay);

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

        [Test]
        public void Execute_WithWeeklyFrequency_SavesFrequencyAndSetsPayDayToDefaultWeeklyPayDay()
        {
            const int oldFrequency = (int)Frequency.Monthly;
            const int newFrequency = (int)Frequency.Weekly;
            const int defaultWeeklyPayDay = (int) Weekday.Friday;
            var request = new SaveSettingsRequestInTest(oldFrequency: oldFrequency, newFrequency: newFrequency);

            var sut = GetSut();
            sut.Execute(request);

            GetMock<IStorage>().Verify(o => o.SetFrequency(newFrequency));
            GetMock<IStorage>().Verify(o => o.SetPayDay(defaultWeeklyPayDay));
        }

        [Test]
        public void Execute_WithMonthlyFrequency_SavesFrequencyAndSetsPayDayToDefaultMonthlyPayDay()
        {
            const int oldFrequency = (int)Frequency.Weekly;
            const int newFrequency = (int)Frequency.Monthly;
            const int defaultMonthlyPayDay = 25;
            var request = new SaveSettingsRequestInTest(oldFrequency: oldFrequency, newFrequency: newFrequency);

            var sut = GetSut();
            sut.Execute(request);

            GetMock<IStorage>().Verify(o => o.SetFrequency(newFrequency));
            GetMock<IStorage>().Verify(o => o.SetPayDay(defaultMonthlyPayDay));
        }

        [Test]
        public void Execute_WithoutFrequency_DoesntSaveFrequency()
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
