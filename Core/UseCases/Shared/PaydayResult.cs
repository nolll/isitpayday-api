using System;

namespace Core.UseCases.Shared;

public record PaydayResult(bool IsPayDay, DateTime NextPayDay, DateTime LocalTime);