using Core.UseCases.GetPayDay;

namespace Tests.Common.FakeClasses
{
    public class ShowPayDayResultInTest : ShowPayDayResult
    {
        public ShowPayDayResultInTest(
            bool isPayDay = default(bool),
            string message = default(string))
            : base(isPayDay, message)
        {
        }
    }
}