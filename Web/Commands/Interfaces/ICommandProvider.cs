using Web.Models;

namespace Web.Commands
{
    public interface ICommandProvider
    {
        Command GetSaveSettingsCommand(IndexPagePostModel postModel);
    }
}