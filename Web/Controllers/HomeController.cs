using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageBuilder _pageBuilder;

        public HomeController(IPageBuilder pageBuilder)
        {
            _pageBuilder = pageBuilder;
        }

        public ActionResult Index()
        {
            var pageModel = _pageBuilder.Build();
            return View(pageModel);
        }

    }

    public interface IPageBuilder
    {
        IndexPageModel Build();
    }

    public class PageBuilder : IPageBuilder
    {
        private readonly IPayDayService _payDayService;

        public PageBuilder(IPayDayService payDayService)
        {
            _payDayService = payDayService;
        }

        public IndexPageModel Build()
        {
            var payDayString = _payDayService.IsPayDay ? "YES!!1!" : "No =(";

            return new IndexPageModel(payDayString);
        }
    }

    public interface IPayDayService
    {
        bool IsPayDay { get; }
    }

    public class PayDayService : IPayDayService
    {
        public bool IsPayDay
        {
            get { return false; }
        }
    }

    public class IndexPageModel
    {
        public IndexPageModel(
            string payDayString)
        {
            PayDayString = payDayString;
        }

        public string PayDayString { get; private set; }
    }
}
