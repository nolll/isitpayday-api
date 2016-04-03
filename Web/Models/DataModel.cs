using Core.UseCases;

namespace Web.Models
{
    public class DataModel
    {
        public bool IsPayDay { get; }

        public DataModel(ShowPayDay.Result showPayDayResult)
        {
            IsPayDay = showPayDayResult.IsPayDay;
        }
    }
}