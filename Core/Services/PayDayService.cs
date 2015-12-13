using System;
using Core.Classes;
using Core.DateEvaluators;

namespace Core.Services
{
    public static class PayDayService
    {
        public static bool IsPayDay(DateTime utcTime, UserSettings userSettings)
        {
            var localTime = TimeZoneInfo.ConvertTime(utcTime, userSettings.TimeZone);
            var actualPayDay = PayDayEvaluator.GetActualPayDay(localTime, userSettings.PayDay);
            return localTime.Day == actualPayDay.Day;
        }
    }
}