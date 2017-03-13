﻿using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class OptionsController : BaseController
    {
        [HttpGet]
        [Route(Routes.ApiOptions)]
        public ActionResult Index()
        {
            var optionsResult = UseCase.Options.Execute();

            return JsonView(new OptionsModel(optionsResult));
        }
    }
}
