using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data.Levels;
using Assets.Scripts.Data;

namespace Assets.Scripts.Architecture.Services
{
    public class SaveProgressService : ISaveProgressService
    {
        private readonly IAssetProvider _assetProvider;
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;

        public SaveProgressService(IAssetProvider assetProvider, ICurrentLevelSettingsProvider currentLevelSettingsProvider)
        {
            _assetProvider = assetProvider;
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
        }

        public void SaveLevelProgress()
        {
            AllLevelsSettings levels = _assetProvider.Initialize<AllLevelsSettings>(AssetPath.AllLevelsSettings);

            for (int i = 0; i < levels.Levels.Count - 1; i++)
            {
                if (levels.Levels[i].Id == _currentLevelSettingsProvider.GetCurrentLevelSettings().Id)
                    levels.Levels[i + 1].IsLevelOpened = true;
            }
        }
    }
}