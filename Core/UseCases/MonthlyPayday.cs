﻿using System;
using Core.DateEvaluators;
using Core.Services;
using Core.UseCases.Shared;

namespace Core.UseCases;

public class MonthlyPayday
{
    public PaydayResult Execute(Request request)
    {
        ValidateRequestOrThrow(request);

        var utcTime = request.UtcTime;
        var country = CountryService.GetCountry(request.CountryCode);
        var timezone = TimezoneService.GetTimezone(request.TimezoneId);
        var evaluator = new MonthlyPayDayEvaluator(country, utcTime, timezone, request.PayDay);
        var isPayDay = evaluator.IsPayDay;
        var nextPayDay = evaluator.NextPayDay;
        var localTime = TimeZoneInfo.ConvertTime(utcTime, timezone);
        return new PaydayResult(isPayDay, nextPayDay, localTime);
    }

    public class Request
    {
        public int PayDay { get; }
        public string CountryCode { get; }
        public string TimezoneId { get; }
        public DateTime UtcTime { get; }

        public Request(int payDay, string countryCode, string timezoneId, DateTime utcTime)
        {
            PayDay = payDay;
            CountryCode = countryCode;
            TimezoneId = timezoneId;
            UtcTime = utcTime;
        }
    }

    private static void ValidateRequestOrThrow(Request request)
    {
        ValidatePaydayOrThrow(request.PayDay);
        ValidateCountryOrThrow(request.CountryCode);
        ValidateTimezoneOrThrow(request.TimezoneId);
    }

    private static void ValidatePaydayOrThrow(int payday)
    {
        if (payday < 1 || payday > 31)
            throw new ArgumentOutOfRangeException(nameof(payday), payday, "Payday has to be between 1 and 31");
    }

    private static void ValidateCountryOrThrow(string countryCode)
    {
        if (string.IsNullOrEmpty(countryCode))
            throw new ArgumentException("No country code provided", nameof(countryCode));
    }

    private static void ValidateTimezoneOrThrow(string timezoneId)
    {
        if (string.IsNullOrEmpty(timezoneId))
            throw new ArgumentException("No timezone provided", nameof(timezoneId));
    }
}