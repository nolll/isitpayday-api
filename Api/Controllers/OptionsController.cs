using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class OptionsController : BaseController
{
    [HttpGet]
    [Route(Routes.ApiOptions)]
    public ActionResult Index()
    {
        var optionsResult = UseCase.Options.Execute();

        return Json(new OptionsModel(optionsResult));
    }
}