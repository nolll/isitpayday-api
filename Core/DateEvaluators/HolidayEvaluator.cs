﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Core.Classes;
using Core.DateEvaluators.CountrySpecific;
using Core.HolidayRules;

namespace Core.DateEvaluators;

public abstract class HolidayEvaluator
{
    protected abstract IEnumerable<HolidayRule> HolidayRules { get; }

    public bool IsHoliday(DateTime userTime)
    {
        return GetHolidays(userTime.Year).Contains(userTime.Date);
    }

    private List<DateTime> GetHolidays(int year)
    {
        return HolidayRules.Select(o => o.GetDate(year)).ToList();
    }

    public static HolidayEvaluator Create(Country? country)
    {
        if (country == null)
            return new DefaultHolidayEvaluator();

        return Evaluators.TryGetValue(country.CultureName, out var evaluator) ? evaluator : new DefaultHolidayEvaluator();
    }

    public static readonly Dictionary<string, HolidayEvaluator> Evaluators = new()
    {
        { CultureCode.Denmark, new DenmarkHolidayEvaluator() },
        { CultureCode.Norway, new NorwayHolidayEvaluator() },
        { CultureCode.Sweden, new SwedenHolidayEvaluator() },
        { CultureCode.UnitedStates, new UnitedStatesHolidayEvaluator() }
    };
}