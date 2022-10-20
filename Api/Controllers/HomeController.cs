using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class HomeController : BaseController
{
    [HttpGet]
    [Route(Routes.Home)]
    public ActionResult Index()
    {
        return Redirect("/api");
    }
}