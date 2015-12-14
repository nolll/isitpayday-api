using Core.Classes;
using Core.UseCases;
using NUnit.Framework;
using Tests.Common;

namespace Core.Tests.UseCases
{
    public class WeeklyPayDayTests : MockContainer
    {
        [Test]
        public void Execute_TodayIsPayDay_IsTrue()
        {
            var request = new ShowPayDay.Request((int)Weekday.Friday, (int)Frequency.Weekly, null, TestData.Timezones.Utc, TestData.Dates.UnblockedFriday);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.IsTrue(result.IsPayDay);
        }

        [Test]
        public void Execute_TodayIsNotPayDay_IsFalse()
        {
            var request = new ShowPayDay.Request((int)Weekday.Thursday, (int)Frequency.Weekly, null, TestData.Timezones.Utc, TestData.Dates.UnblockedFriday);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.IsFalse(result.IsPayDay);
        }

        [Test]
        public void Execute_TomorrowIsChristmasEve_TodayIsPayday()
        {
            var request = new ShowPayDay.Request((int)Weekday.Thursday, (int)Frequency.Weekly, null, TestData.Timezones.Utc, TestData.Dates.DayBeforeChristmasEve);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.IsTrue(result.IsPayDay);
        }

        private ShowPayDay GetSut()
        {
            return new ShowPayDay();
        }
    }
}
