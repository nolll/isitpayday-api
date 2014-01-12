using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Web.Models;
using Web.PageBuilders;
using Web.Storage;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageBuilder _pageBuilder;
        private readonly ICommandProvider _commandProvider;

        public HomeController(
            IPageBuilder pageBuilder,
            ICommandProvider commandProvider)
        {
            _pageBuilder = pageBuilder;
            _commandProvider = commandProvider;
        }

        public ActionResult Index(string change)
        {
            var pageModel = _pageBuilder.Build(change);
            return View(pageModel);
        }

        [HttpPost]
        public ActionResult Index(string change, IndexPagePostModel postModel)
        {
            var command = _commandProvider.GetSaveSettingsCommand(postModel);
            var pageModel = _pageBuilder.Build();
            return View(pageModel);
        }

    }

    public interface ICommandProvider
    {
        Command GetSaveSettingsCommand(IndexPagePostModel postModel);
    }

    public class CommandProvider : ICommandProvider
    {
        private readonly IStorage _storage;

        public CommandProvider(IStorage storage)
        {
            _storage = storage;
        }

        public Command GetSaveSettingsCommand(IndexPagePostModel postModel)
        {
            return new SaveSettingsCommand(_storage, postModel);
        }
    }

    public class SaveSettingsCommand : Command
    {
        private readonly IStorage _storage;
        private readonly IndexPagePostModel _model;

        public SaveSettingsCommand(
            IStorage storage,
            IndexPagePostModel model)
        {
            _storage = storage;
            _model = model;
        }

        public override bool Execute()
        {
            if (_model.CountryId != null)
            {
                return true;
            }
            if (_model.TimeZone != null)
            {
                return true;
            }
            if (_model.PayDay.HasValue)
            {

                return true;
            }
            return false;
        }
    }

    public abstract class Command
    {
        private readonly IList<ValidationResult> _errors;

        protected Command()
        {
            _errors = new List<ValidationResult>();
        }

        protected bool IsValid(object model)
        {
            var context = new ValidationContext(model, null, null);
            if (!Validator.TryValidateObject(model, context, _errors))
            {
                return false;
            }
            return true;
        }

        protected void AddError(string message)
        {
            _errors.Add(new ValidationResult(message));
        }

        public IEnumerable<string> Errors
        {
            get { return _errors.Select(o => o.ErrorMessage); }
        }

        protected bool HasErrors
        {
            get { return _errors.Count > 0; }
        }

        public abstract bool Execute();
    }
}
