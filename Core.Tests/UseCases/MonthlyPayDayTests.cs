﻿using System;
using Core.UseCases;
using NUnit.Framework;
using Tests.Common;

namespace Core.Tests.UseCases
{
    public class MonthlyPayDayTests : MockContainer
    {
        [Test]
        public void Execute_TodayIsPayDay_IsTrue()
        {
            var time = new DateTime(2000, 1, 25, 12, 0, 0, DateTimeKind.Utc);
            var request = new ShowPayDay.Request(25, null, null, "UTC", time);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.IsTrue(result.IsPayDay);
        }

        [Test]
        public void Execute_TodayIsNotPayDay_IsFalse()
        {
            var time = new DateTime(2000, 1, 24, 12, 0, 0, DateTimeKind.Utc);
            var request = new ShowPayDay.Request(25, null, null, "UTC", time);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.IsFalse(result.IsPayDay);
        }

        [Test]
        public void Execute_TodayIsNotPayDayButMonthIsTooShortAndFallbacks_IsTrue()
        {
            var request = new ShowPayDay.Request(31, null, null, "UTC", TestData.Dates.LeapYearFeb29th);

            var sut = GetSut();
            var result = sut.Execute(request);

            Assert.IsTrue(result.IsPayDay);
        }

        [Test]
        public void Execute_UserTimeIsSet()
        {
            var time = new DateTime(2000, 1, 1, 12, 0, 0, DateTimeKind.Utc);
            var request = new ShowPayDay.Request(25, null, null, "UTC", time);

            var sut = GetSut();
            var result = sut.Execute(request);

            // todo: test one more time zone
            Assert.AreEqual(time, result.LocalTime);
        }

        private ShowPayDay GetSut()
        {
            return new ShowPayDay();
        }
    }
}