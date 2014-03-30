using System;

namespace Core.UseCases
{
    public class ShowPayDayResult
    {
        public bool IsPayDay { get; private set; }
        public string Message { get; private set; }
        public DateTime UserTime { get; private set; }

        public ShowPayDayResult(bool isPayDay, string message, DateTime userTime)
        {
            IsPayDay = isPayDay;
            Message = message;
            UserTime = userTime;
        }
    }
}