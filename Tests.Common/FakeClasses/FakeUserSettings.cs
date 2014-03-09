using System;
using Core.Classes;

namespace Tests.Common.FakeClasses
{
    public class FakeUserSettings : UserSettings
    {
        public FakeUserSettings(
            Country country = default(Country),
            TimeZoneInfo timeZone = default(TimeZoneInfo),
            int payDay = default(int))
            : base(
            country,
            timeZone,
            payDay)
        {
        }
    }
}
