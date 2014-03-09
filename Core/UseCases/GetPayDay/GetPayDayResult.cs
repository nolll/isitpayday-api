namespace Core.UseCases.GetPayDay
{
    public class GetPayDayResult
    {
        public bool IsPayDay { get; private set; }
        public string Message { get; private set; }

        public GetPayDayResult(bool isPayDay, string message)
        {
            IsPayDay = isPayDay;
            Message = message;
        }
    }
}