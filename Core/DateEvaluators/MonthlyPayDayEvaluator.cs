using System;
using Core.Classes;

namespace Core.DateEvaluators;

public class MonthlyPayDayEvaluator(Country country, DateTime utcTime, TimeZoneInfo timezone, int day)
{
    private readonly BlockedEvaluator _blockedEvaluator = new(country);

    private DateTime LocalTime => TimeZoneInfo.ConvertTime(utcTime, timezone);
    public bool IsPayDay => LocalTime.Date == NextPayDay;

    public DateTime NextPayDay
    {
        get
        {
            var payDayDate = GetNextPayDate(LocalTime);
            while (_blockedEvaluator.IsBlocked(payDayDate))
            {
                payDayDate = payDayDate.AddDays(-1);
            }
            return payDayDate.Date;
        }
    }

    private DateTime GetNextPayDate(DateTime localTime)
    {
        var payDay = AdjustPayDayForShortMonths(localTime);
        while (localTime.Day != payDay)
        {
            localTime = localTime.AddDays(1);
        }
        return localTime;
    }

    private int AdjustPayDayForShortMonths(DateTime localTime)
    {
        var payDay = day;
        while (!IsMonthLongEnough(localTime, payDay))
        {
            payDay--;
        }
        return payDay;
    }

    private static bool IsMonthLongEnough(DateTime time, int payDay)
    {
        try
        {
            var foo = new DateTime(time.Year, time.Month, payDay);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}