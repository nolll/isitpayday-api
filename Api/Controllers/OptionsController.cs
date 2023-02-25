using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers;

public class OptionsController : BaseController
{
    [HttpGet]
    [Route(Routes.ApiOptions)]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult Options()
    {
        var optionsResult = UseCase.Options.Execute();

        return Json(new OptionsModel(optionsResult));
    }

    /// <summary>
    /// Get all possible countries.
    /// </summary>
    /// <returns>A list of countries.</returns>
    [HttpGet]
    [Route(Routes.ApiCountries)]
    public ActionResult Countries()
    {
        var optionsResult = UseCase.Options.Execute();
        var models = optionsResult.CountryOptions.Select(o => new CountryModel(o.Id, o.Name)).ToList();

        return Json(models);
    }

    /// <summary>
    /// Get all payday frequencies.
    /// </summary>
    /// <returns>A list of frequencies.</returns>
    [HttpGet]
    [Route(Routes.ApiFrequencies)]
    public ActionResult Frequencies()
    {
        var optionsResult = UseCase.Options.Execute();
        var models = optionsResult.FrequencyOptions.Select(o => new FrequencyModel(o.Id, o.Name)).ToList();

        return Json(models);
    }

    [HttpGet]
    [Route(Routes.ApiOptionsOld)]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult OptionsOld()
    {
        return Options();
    }

    [HttpGet]
    [Route(Routes.ApiCountriesOld)]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult CountriesOld()
    {
        return Countries();
    }

    [HttpGet]
    [Route(Routes.ApiFrequenciesOld)]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult FrequenciesOld()
    {
        return Frequencies();
    }
}