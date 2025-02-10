using System;
using Core.UseCases.Shared;
using JetBrains.Annotations;

namespace Api.Models;

public class PayDayModel(PaydayResult showPayDayResult)
{
    [UsedImplicitly]
    public bool IsPayDay { get; } = showPayDayResult.IsPayDay;

    [UsedImplicitly]
    public string NextPayDay { get; } = showPayDayResult.NextPayDay.ToString("yyyy-MM-dd");

    [UsedImplicitly]
    public DateTime LocalTime { get; } = showPayDayResult.LocalTime;
}