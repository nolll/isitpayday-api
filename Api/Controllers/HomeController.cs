using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class HomeController : BaseController
{
    [HttpGet]
    [Route(Routes.Home)]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult Index() => Redirect("/swagger/index.html");
}