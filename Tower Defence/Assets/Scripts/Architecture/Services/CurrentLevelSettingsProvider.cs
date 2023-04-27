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

        public LevelSettings GetCurrentLevelSettings() => 
            _levels.Levels.Find(x => x.Id.ToString() == SceneManager.GetActiveScene().name);
    }
}