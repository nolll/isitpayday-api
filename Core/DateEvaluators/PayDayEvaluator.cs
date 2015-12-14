using System;
using Core.Classes;

namespace Core.DateEvaluators
{
    public abstract class PayDayEvaluator
    {
        public static PayDayEvaluator Create(PayDayType type, DateTime userTime, TimeZoneInfo timezone, int payDay)
        {
            if(type == PayDayType.Weekly)
                return new WeeklyPayDayEvaluator(userTime, timezone, payDay);
            return new MonthlyPayDayEvaluator(userTime, timezone, payDay);
        }

        public abstract bool IsPayDay { get; }

        private class MonthlyPayDayEvaluator : PayDayEvaluator
        {
            private readonly DateTime _utcTime;
            private readonly TimeZoneInfo _timezone;
            private readonly int _payDay;

            public MonthlyPayDayEvaluator(DateTime utcTime, TimeZoneInfo timezone, int payDay)
            {
                _utcTime = utcTime;
                _timezone = timezone;
                _payDay = payDay;
            }

            public override bool IsPayDay
            {
                get
                {
                    var localTime = TimeZoneInfo.ConvertTime(_utcTime, _timezone);
                    var payDayDate = GetNextPayDay(localTime);
                    while (BlockedEvaluator.IsBlocked(payDayDate))
                    {
                        payDayDate = payDayDate.AddDays(-1);
                    }
                    return localTime.Date == payDayDate.Date;
                }
            }

            private DateTime GetNextPayDay(DateTime localTime)
            {
                while (localTime.Day != _payDay)
                {
                    localTime = localTime.AddDays(1);
                }
                return localTime;
            }
        }

        private class WeeklyPayDayEvaluator : PayDayEvaluator
        {
            private readonly DateTime _utcTime;
            private readonly TimeZoneInfo _timezone;
            private readonly int _payDay;

            public WeeklyPayDayEvaluator(DateTime utcTime, TimeZoneInfo timezone, int payDay)
            {
                _utcTime = utcTime;
                _timezone = timezone;
                _payDay = payDay;
            }

            public override bool IsPayDay
            {
                get
                {
                    var localTime = TimeZoneInfo.ConvertTime(_utcTime, _timezone);
                    var payDayDate = GetNextPayDay(localTime);
                    while (BlockedEvaluator.IsBlocked(payDayDate))
                    {
                        payDayDate = payDayDate.AddDays(-1);
                    }
                    return localTime.Date == payDayDate.Date;
                }
            }

            private DateTime GetNextPayDay(DateTime localTime)
            {
                var weekDay = GetWeekday(localTime);
                while ((int) weekDay != _payDay)
                {
                    localTime = localTime.AddDays(1);
                    weekDay = GetWeekday(localTime);
                }
                return localTime;
            }

            private Weekday GetWeekday(DateTime localTime)
            {
                var dayOfWeek = localTime.DayOfWeek;
                if (dayOfWeek == DayOfWeek.Monday)
                    return Weekday.Monday;
                if (dayOfWeek == DayOfWeek.Tuesday)
                    return Weekday.Tuesday;
                if (dayOfWeek == DayOfWeek.Wednesday)
                    return Weekday.Wednesday;
                if (dayOfWeek == DayOfWeek.Thursday)
                    return Weekday.Thursday;
                if (dayOfWeek == DayOfWeek.Friday)
                    return Weekday.Friday;
                if (dayOfWeek == DayOfWeek.Saturday)
                    return Weekday.Saturday;
                return Weekday.Sunday;
            }
        }
    }
}