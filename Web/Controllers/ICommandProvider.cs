using Web.Models;

namespace Web.Controllers
{
    public interface ICommandProvider
    {
        Command GetSaveSettingsCommand(IndexPagePostModel postModel);
    }
}