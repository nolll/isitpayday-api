using System;
using Core.WeekendRules;

namespace Core.DateEvaluators;

public static class WeekendEvaluator
{
    public static bool IsWeekend(DateTime userTime) => WeekendRule.IsWeekend(userTime);
}