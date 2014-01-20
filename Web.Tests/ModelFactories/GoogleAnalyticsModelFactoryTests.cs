using Core.Services;
using NUnit.Framework;
using Tests.Common;
using Web.ModelFactories;

namespace Web.Tests.ModelFactories
{
    public class GoogleAnalyticsModelFactoryTests : MockContainer
    {
        [Test]
        public void Code_IsSetToCorrectCode()
        {
            const string expected = "UA-8453410-4";

            var sut = GetSut();
            var result = sut.Create();

            Assert.AreEqual(expected, result.Code);
        }

        [Test]
        public void Enabled_IsNotInProduction_ReturnsFalse()
        {
            GetMock<IWebContext>().SetupGet(o => o.IsInProduction).Returns(false);

            var sut = GetSut();
            var result = sut.Create();

            Assert.IsFalse(result.Enabled);
        }

        [Test]
        public void Enabled_IsInProduction_ReturnsTrue()
        {
            GetMock<IWebContext>().SetupGet(o => o.IsInProduction).Returns(true);

            var sut = GetSut();
            var result = sut.Create();

            Assert.IsTrue(result.Enabled);
        }

        private GoogleAnalyticsModelFactory GetSut()
        {
            return new GoogleAnalyticsModelFactory(
                GetMock<IWebContext>().Object);
        }
    }
}
