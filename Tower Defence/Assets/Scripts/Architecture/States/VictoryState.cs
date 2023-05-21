using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Audio;
using Assets.Scripts.Data.Windows;

namespace Assets.Scripts.Architecture.States
{
    public class VictoryState : IState
    {
        private readonly IWindowService _windowService;
        private readonly IAudioService _audioService;
        private readonly ISaveProgressService _saveProgressService;

        public VictoryState(IWindowService windowService, IAudioService audioService, ISaveProgressService saveProgressService)
        {
            _windowService = windowService;
            _audioService = audioService;
            _saveProgressService = saveProgressService;
        }
        
        public void Exit()
        {
        }

        public void Enter()
        {
            _audioService.StopMusic();
            _audioService.PlaySfx(SfxType.Win);
            _windowService.Open(WindowId.Victory);
            _saveProgressService.SaveLevelProgress();
        }
    }
}