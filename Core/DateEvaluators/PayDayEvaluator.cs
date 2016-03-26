using System;
using Core.Classes;

namespace Core.DateEvaluators
{
    public abstract class PayDayEvaluator
    {
        public static PayDayEvaluator Create(Frequency type, Country country, DateTime userTime, TimeZoneInfo timezone, int payDay)
        {
            if(type == Frequency.Weekly)
                return new WeeklyPayDayEvaluator(country, userTime, timezone, payDay);
            return new MonthlyPayDayEvaluator(country, userTime, timezone, payDay);
        }

        public abstract bool IsPayDay { get; }

        private class MonthlyPayDayEvaluator : PayDayEvaluator
        {
            private readonly Country _country;
            private readonly DateTime _utcTime;
            private readonly TimeZoneInfo _timezone;
            private readonly int _payDay;

            public MonthlyPayDayEvaluator(Country country, DateTime utcTime, TimeZoneInfo timezone, int payDay)
            {
                _country = country;
                _utcTime = utcTime;
                _timezone = timezone;
                _payDay = payDay;
            }

            public override bool IsPayDay
            {
                get
                {
                    var localTime = TimeZoneInfo.ConvertTime(_utcTime, _timezone);
                    var payDayDate = GetNextPayDate(localTime);
                    while (BlockedEvaluator.IsBlocked(_country, payDayDate))
                    {
                        payDayDate = payDayDate.AddDays(-1);
                    }
                    return localTime.Date == payDayDate.Date;
                }
            }

            private DateTime GetNextPayDate(DateTime localTime)
            {
                var payDay = AdjustPayDayForShortMonths(localTime);
                return FindPayDate(localTime, payDay);
            }

            private DateTime FindPayDate(DateTime localTime, int payDay)
            {
                while (localTime.Day != payDay)
                {
                    localTime = localTime.AddDays(1);
                }
                return localTime;
            }

            private int AdjustPayDayForShortMonths(DateTime localTime)
            {
                var payDay = _payDay;
                while (!IsMonthLongEnough(localTime, payDay))
                {
                    payDay--;
                }
                return payDay;
            }

            private bool IsMonthLongEnough(DateTime time, int payDay)
            {
                try
                {
                    var foo = new DateTime(time.Year, time.Month, payDay);
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
        }

        private class WeeklyPayDayEvaluator : PayDayEvaluator
        {
            private readonly Country _country;
            private readonly DateTime _utcTime;
            private readonly TimeZoneInfo _timezone;
            private readonly int _payDay;

            public WeeklyPayDayEvaluator(Country country, DateTime utcTime, TimeZoneInfo timezone, int payDay)
            {
                _country = country;
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
                    while (BlockedEvaluator.IsBlocked(_country, payDayDate))
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