namespace Core.UseCases.GetPayDay
{
    public class ShowPayDayResult
    {
        public bool IsPayDay { get; private set; }
        public string Message { get; private set; }

        public ShowPayDayResult(bool isPayDay, string message)
        {
            IsPayDay = isPayDay;
            Message = message;
        }
    }
}