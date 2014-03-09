using Core.Services;
using Core.UseCases.GetPayDay;
using NUnit.Framework;
using Tests.Common;
using Tests.Common.FakeClasses;

namespace Core.Tests.Interactors
{
    public class GetPayDayInteractorTests : MockContainer
    {
        [Test]
        public void Execute_TodayIsPayDay_ResultIsCorrect()
        {
            const int payDay = 1;
            var userSettings = new FakeUserSettings(payDay: payDay);
            const string expectedMessage = "YES!!1!";

            GetMock<IPayDayService>().Setup(o => o.IsPayDay(userSettings)).Returns(true);

            var sut = GetSut();
            var result = sut.Execute(userSettings);

            Assert.IsTrue(result.IsPayDay);
            Assert.AreEqual(expectedMessage, result.Message);
        }
        
        [Test]
        public void Execute_TodayIsNotPayDay_ResultIsCorrect()
        {
            const int payDay = 1;
            var userSettings = new FakeUserSettings(payDay: payDay);
            const string expectedMessage = "No =(";

            GetMock<IPayDayService>().Setup(o => o.IsPayDay(userSettings)).Returns(false);

            var sut = GetSut();
            var result = sut.Execute(userSettings);

            Assert.IsFalse(result.IsPayDay);
            Assert.AreEqual(expectedMessage, result.Message);
        }

        private GetPayDayInteractor GetSut()
        {
            return new GetPayDayInteractor(
                GetMock<IPayDayService>().Object);
        }
    }
}
