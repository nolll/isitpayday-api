using Core.UseCases.GetPayDay;

namespace Tests.Common.FakeClasses
{
    public class FakeShowPayDayResult : ShowPayDayResult
    {
        public FakeShowPayDayResult(
            bool isPayDay = default(bool),
            string message = default(string))
            : base(isPayDay, message)
        {
        }
    }
}