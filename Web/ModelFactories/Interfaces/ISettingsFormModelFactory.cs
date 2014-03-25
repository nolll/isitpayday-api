using Core.Classes;
using Web.Models;

namespace Web.ModelFactories
{
    public interface ISettingsFormModelFactory
    {
        SettingsFormModel Create(UserSettings userSettings, string activeForm);
    }
}