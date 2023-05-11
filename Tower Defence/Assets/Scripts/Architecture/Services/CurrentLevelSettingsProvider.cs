using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data.Levels;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Architecture.Services
{
    public class CurrentLevelSettingsProvider : ICurrentLevelSettingsProvider
    {
        private readonly AllLevelsSettings _levels;

        public CurrentLevelSettingsProvider(AllLevelsSettings levels) =>
            _levels = levels;

        public LevelSettings GetCurrentLevelSettings()
        {
            LevelSettings levelSettings = new LevelSettings();

            foreach (LevelSettings level in _levels.Levels)
            {
                if (level.Id.ToString() == SceneManager.GetActiveScene().name)
                {
                    levelSettings = level;
                    return levelSettings;
                }
            }

            return levelSettings;
        }
    }
}