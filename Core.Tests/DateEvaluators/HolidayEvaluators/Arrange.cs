using System;
using Core.Classes;
using Core.DateEvaluators;
using NUnit.Framework;
using Tests.Common.FakeClasses;

namespace Core.Tests.DateEvaluators.HolidayEvaluators
{
    public class Arrange
    {
        private Country _country;
        protected virtual string CountryCode => "";
        
        [SetUp]
        public void Setup()
        {
            _country = new CountryInTest(CountryCode);
        }

        protected bool IsHoliday(string date)
        {
            var evaluator = CountryEvaluator.GetEvaluator(_country);
            return evaluator.IsHoliday(DateTime.Parse(date));
        }
    }
}