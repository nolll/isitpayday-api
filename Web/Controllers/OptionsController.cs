using System.Web.Http;
using Web.Models;

namespace Web.Controllers
{
    public class OptionsController : BaseApiController
    {
        [HttpGet]
        public OptionsModel Index()
        {
            var optionsResult = UseCase.Options.Execute();

            return new OptionsModel(optionsResult);
        }
    }
}
