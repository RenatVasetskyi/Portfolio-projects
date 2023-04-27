using Assets.Scripts.Data.Levels;

namespace Assets.Scripts.Architecture.Services.Interfaces
{
    public interface ICurrentLevelSettingsProvider
    {
        LevelSettings GetCurrentLevelSettings();
    }
}