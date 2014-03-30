using System;
using Core.UseCases;

namespace Tests.Common.FakeClasses
{
    public class ShowPayDayResultInTest : ShowPayDayResult
    {
        public ShowPayDayResultInTest(
            bool isPayDay = default(bool),
            string message = default(string),
            DateTime userTime = default(DateTime))
            : base(isPayDay, message, userTime)
        {
        }
    }
}