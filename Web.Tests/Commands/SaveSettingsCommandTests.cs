using Core.UseCases;
using Moq;
using NUnit.Framework;
using Tests.Common;
using Web.Commands;
using Web.Models;

namespace Web.Tests.Commands
{
    public class SaveSettingsCommandTests : MockContainer
    {
        [Test]
        public void Execute_WithPostModel_CallsInteractorWithRequest()
        {
            const string countryId = "a";
            const string timeZoneId = "b";
            const int payDay = 1;

            var postModel = new SettingsPostModel{ CountryId = countryId, TimeZoneId = timeZoneId, PayDay = payDay};

            var sut = GetSut(postModel);
            var result = sut.Execute();

            Assert.IsTrue(result);
            GetMock<ISaveSettings>().Verify(o => o.Execute(It.Is<SaveSettingsRequest>(r => r.CountryId == countryId && r.TimeZoneId == timeZoneId && r.PayDay == payDay)));
        }

        private SaveSettingsCommand GetSut(SettingsPostModel postModel)
        {
            return new SaveSettingsCommand(
                GetMock<ISaveSettings>().Object,
                postModel);
        }
    }
}
