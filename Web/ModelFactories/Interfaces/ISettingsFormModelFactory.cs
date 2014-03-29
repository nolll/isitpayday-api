using Web.Models;

namespace Web.ModelFactories
{
    public interface ISettingsFormModelFactory
    {
        SettingsFormModel Create(string activeForm);
    }
}