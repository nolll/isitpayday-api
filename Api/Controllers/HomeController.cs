using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class HomeController : BaseController
{
    [HttpGet]
    [Route(Routes.Home)]
    public ActionResult Index()
    {
        return Redirect("/api");
    }
}