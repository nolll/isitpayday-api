using System;
using Core.Classes;
using Core.DateEvaluators;
using NUnit.Framework;
using Tests.Common.FakeClasses;

namespace Core.Tests.DateEvaluators.HolidayEvaluators
{
    public class Arrange
    {
        protected Country Country;
        protected virtual string CountryCode => "";
        
        [SetUp]
        public void Setup()
        {
            Country = new CountryInTest(CountryCode);
        }

        protected bool IsHoliday(string date)
        {
            return HolidayEvaluator.IsHoliday(Country, DateTime.Parse(date));
        }
    }
}