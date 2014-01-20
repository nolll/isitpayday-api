using System;
using Moq;
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;
using Web.PageBuilders;
using Web.Services;

namespace Web.Tests.PageBuilders
{
    public class PageBuilderTests : MockContainer
    {
        [Test]
        public void PayDayString_WithNonPayDay_IsCorrectString()
        {
            var activeForm = It.IsAny<string>();
            const string expected = "No =(";

            GetMock<IPayDayService>().Setup(o => o.IsPayDay(It.IsAny<DateTime>(), It.IsAny<int>())).Returns(false);
            GetMock<ICountryService>().Setup(o => o.GetTimeZone()).Returns(TimeZoneInfo.Utc);
            GetMock<ICountryService>().Setup(o => o.GetCountry()).Returns(new FakeCountry());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.AreEqual(expected, result.PayDayString);
        }

        [Test]
        public void PayDayString_WithPayDay_IsCorrectString()
        {
            var activeForm = It.IsAny<string>();
            const string expected = "YES!!1!";

            GetMock<IPayDayService>().Setup(o => o.IsPayDay(It.IsAny<DateTime>(), It.IsAny<int>())).Returns(true);
            GetMock<ICountryService>().Setup(o => o.GetTimeZone()).Returns(TimeZoneInfo.Utc);
            GetMock<ICountryService>().Setup(o => o.GetCountry()).Returns(new FakeCountry());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.AreEqual(expected, result.PayDayString);
        }

        [Test]
        public void PayDay_WithPayDay_IsSetFromSelectedPayDay()
        {
            var activeForm = It.IsAny<string>();
            const int selectedPayDay = 1;

            GetMock<IPayDayService>().Setup(o => o.GetSelectedPayDay()).Returns(selectedPayDay);
            GetMock<ICountryService>().Setup(o => o.GetTimeZone()).Returns(TimeZoneInfo.Utc);
            GetMock<ICountryService>().Setup(o => o.GetCountry()).Returns(new FakeCountry());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.AreEqual(selectedPayDay, result.PayDay);
        }

        [Test]
        public void Timezone_WithTimezone_NameAndIdIsSet()
        {
            var activeForm = It.IsAny<string>();
            var timeZone = TimeZoneInfo.Utc;
            const string expectedTimeZoneId = "UTC";
            const string expectedTimeZoneName = "UTC";

            GetMock<ICountryService>().Setup(o => o.GetTimeZone()).Returns(timeZone);
            GetMock<ICountryService>().Setup(o => o.GetCountry()).Returns(new FakeCountry());

            var sut = GetSut();
            var result = sut.Build(activeForm);

            Assert.AreEqual(expectedTimeZoneId, result.TimeZoneId);
            Assert.AreEqual(expectedTimeZoneName, result.TimeZoneName);
        }

        private PageBuilder GetSut()
        {
            return new PageBuilder(
                GetMock<IPayDayService>().Object,
                GetMock<ITimeService>().Object,
                GetMock<ICountryService>().Object,
                GetMock<IGoogleAnalyticsModelFactory>().Object);
        }
    }
}
