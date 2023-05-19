using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Audio;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Levels;
using Assets.Scripts.Data.Windows;

namespace Assets.Scripts.Architecture.States
{
    public class VictoryState : IState
    {
        private readonly IWindowService _windowService;
        private readonly IAudioService _audioService;
        private readonly IAssetProvider _assetProvider;
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;

        public VictoryState(IWindowService windowService, IAudioService audioService, IAssetProvider assetProvider, ICurrentLevelSettingsProvider currentLevelSettingsProvider)
        {
            _windowService = windowService;
            _audioService = audioService;
            _assetProvider = assetProvider;
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
        }
        
        public void Exit()
        {
        }

        public void Enter()
        {
            OpenNextLevel();
            _audioService.StopMusic();
            _audioService.PlaySfx(SfxType.Win);
            _windowService.Open(WindowId.Victory);
        }

        private void OpenNextLevel()
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