using Core.Services;
using Core.UseCases.GetPayDay;
using NUnit.Framework;
using Tests.Common;

namespace Core.Tests.Interactors
{
    public class GetPayDayInteractorTests : MockContainer
    {
        [Test]
        public void Execute_TodayIsPayDay_ResultIsCorrect()
        {
            const string expectedMessage = "YES!!1!";

            GetMock<IPayDayService>().Setup(o => o.IsPayDay()).Returns(true);

            var sut = GetSut();
            var result = sut.Execute();

            Assert.IsTrue(result.IsPayDay);
            Assert.AreEqual(expectedMessage, result.Message);
        }
        
        [Test]
        public void Execute_TodayIsNotPayDay_ResultIsCorrect()
        {
            const string expectedMessage = "No =(";

            GetMock<IPayDayService>().Setup(o => o.IsPayDay()).Returns(false);

            var sut = GetSut();
            var result = sut.Execute();

            Assert.IsFalse(result.IsPayDay);
            Assert.AreEqual(expectedMessage, result.Message);
        }

        private ShowPayDayInteractor GetSut()
        {
            return new ShowPayDayInteractor(
                GetMock<IPayDayService>().Object);
        }
    }
}
