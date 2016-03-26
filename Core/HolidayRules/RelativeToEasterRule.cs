using System;

namespace Core.HolidayRules
{
    public class RelativeToEasterRule : IHolidayRule
    {
        private readonly int _diffInDays;

        public RelativeToEasterRule(int diffInDays)
        {
            _diffInDays = diffInDays;
        }

        public DateTime GetDate(int year)
        {
            return GetEasterSunday(year).AddDays(_diffInDays);
        }

        // The algorithm was found here: http://stackoverflow.com/questions/26022233/calculate-the-date-of-easter-sunday
        private DateTime GetEasterSunday(int year)
        {
            int a = year % 19,
                b = year / 100,
                c = year % 100,
                d = b / 4,
                e = b % 4,
                g = (8 * b + 13) / 25,
                h = (19 * a + b - d - g + 15) % 30,
                j = c / 4,
                k = c % 4,
                m = (a + 11 * h) / 319,
                r = (2 * e + 2 * j - k - h + m + 32) % 7,
                n = (h - m + r + 90) / 25,
                p = (h - m + r + n + 19) % 32;

            return new DateTime(year, n, p);
        }
    }
}