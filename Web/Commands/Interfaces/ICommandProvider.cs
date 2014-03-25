using Web.Models;

namespace Web.Commands
{
    public interface ICommandProvider
    {
        SaveSettingsCommand GetSaveSettingsCommand(SettingsModel postModel);
    }
}