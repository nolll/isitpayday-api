using System;

namespace Core.UseCases.Shared
{
    public class PaydayResult
    {
        public bool IsPayDay { get; }
        public DateTime LocalTime { get; }

        public PaydayResult(bool isPayDay, DateTime localTime)
        {
            IsPayDay = isPayDay;
            LocalTime = localTime;
        }
    }
}