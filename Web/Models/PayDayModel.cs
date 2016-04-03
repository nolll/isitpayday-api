using System;
using Core.UseCases;
using JetBrains.Annotations;

namespace Web.Models
{
    public class PayDayModel
    {
        [UsedImplicitly]
        public bool IsPayDay { get; }

        [UsedImplicitly]
        public DateTime LocalTime { get; }

        public PayDayModel(ShowPayDay.Result showPayDayResult)
        {
            IsPayDay = showPayDayResult.IsPayDay;
            LocalTime = showPayDayResult.LocalTime;
        }
    }
}