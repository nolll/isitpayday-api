using NUnit.Framework;
using Tests.Common;
using Web.Models;

namespace Web.Tests.ModelFactories
{
    public class GoogleAnalyticsModelFactoryTests : MockContainer
    {
        [Test]
        public void Code_IsSetToCorrectCode()
        {
            const string expected = "UA-8453410-4";

            var result = new GoogleAnalyticsModel(true);

            Assert.AreEqual(expected, result.Code);
        }

        [Test]
        public void Enabled_IsNotInProduction_ReturnsFalse()
        {
            var result = new GoogleAnalyticsModel(false);

            Assert.IsFalse(result.Enabled);
        }

        [Test]
        public void Enabled_IsInProduction_ReturnsTrue()
        {
            var result = new GoogleAnalyticsModel(true);

            Assert.IsTrue(result.Enabled);
        }
    }
}
