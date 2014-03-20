using System;
using Core.Classes;

namespace Tests.Common.FakeClasses
{
    public class UserSettingsInTest : UserSettings
    {
        public UserSettingsInTest(
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
