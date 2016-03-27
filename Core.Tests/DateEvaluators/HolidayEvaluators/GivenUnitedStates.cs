using NUnit.Framework;

namespace Core.Tests.DateEvaluators.HolidayEvaluators
{
    public class GivenUnitedStates : Arrange
    {
        protected override string CountryCode => "US";

        [TestCase("2014-01-01")]
        [TestCase("2015-01-01")]
        [TestCase("2016-01-01")]
        [TestCase("2017-01-02")]
        [TestCase("2018-01-01")]
        public void NewYearsDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

        [TestCase("2014-07-04")]
        [TestCase("2015-07-04")]
        [TestCase("2016-07-04")]
        [TestCase("2017-07-04")]
        [TestCase("2018-07-04")]
        public void IndependenceDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

        [TestCase("2014-11-27")]
        [TestCase("2015-11-26")]
        [TestCase("2016-11-24")]
        [TestCase("2017-11-23")]
        [TestCase("2018-11-22")]
        public void ThanksgivingDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

        [TestCase("2014-12-25")]
        [TestCase("2015-12-25")]
        [TestCase("2016-12-26")]
        [TestCase("2017-12-25")]
        [TestCase("2018-12-25")]
        public void ChristmasDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));
    }
}