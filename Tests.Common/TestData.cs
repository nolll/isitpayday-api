using System;

namespace Tests.Common
{
    public static class TestData
    {
        public static class Dates
        {
            public static DateTime UnblockedFriday = new DateTime(2015, 12, 18, 12, 0, 0, DateTimeKind.Utc);
            public static DateTime DayBeforeChristmasEve = new DateTime(2015, 12, 23, 12, 0, 0, DateTimeKind.Utc);
            public static DateTime LeapYearFeb29th = new DateTime(2016, 2, 29, 12, 0, 0, DateTimeKind.Utc);
        }

        public static class Timezones
        {
            public static string Utc = "UTC";
        }
    }
}