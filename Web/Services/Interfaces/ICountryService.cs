using System.Collections.Generic;

namespace Web.Services
{
    public interface ICountryService
    {
        IEnumerable<Country> GetCountries();
    }
}