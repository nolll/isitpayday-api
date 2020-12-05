using NUnit.Framework;
using Web.Models;
using Web.Services;

namespace Web.Tests.ModelFactories
{
    public class GoogleAnalyticsModelFactoryTests
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

        [Test]
        public void Sha256HashIsCorrect()
        {
            Assert.That(GaScriptService.ComputedSha256Hash, Is.EqualTo("k59mZP6VC5mV76DXo+499OqnycIZLp0YneM/hAnfgCg="));
        }
    }
}
