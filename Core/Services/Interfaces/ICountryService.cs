using System.Collections.Generic;
using Core.Classes;

namespace Core.Services
{
    public interface ICountryService
    {
        IEnumerable<Country> GetCountries();
    }
}