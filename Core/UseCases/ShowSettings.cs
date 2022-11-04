using System;
using System.Collections.Generic;
using Core.Classes;
using Core.Services;
using System.Linq;

namespace Core.UseCases;

public class Options
{
    public Result Execute()
    {
        return new Result(
            CountryOptions,
            FrequencyOptions);
    }

    public class Result
    {
        public IList<Country> CountryOptions { get; }
        public IList<Frequency> FrequencyOptions { get; }

        public Result(
            IList<Country> countryOptions,
            IList<Frequency> frequencyOptions)
        {
            CountryOptions = countryOptions;
            FrequencyOptions = frequencyOptions;
        }
    }

    private IList<Country> CountryOptions => CountryService.GetCountries().ToList();
    private IList<Frequency> FrequencyOptions => FrequencyService.GetFrequencies().ToList();
}