namespace Core.UseCases.SaveSettings
{
    public interface ISaveSettingsInteractor
    {
        void Execute(SaveSettingsRequest request);
    }
}