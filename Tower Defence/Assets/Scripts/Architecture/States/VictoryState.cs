using Assets.Scripts.Architecture.Services.Factories.UI;
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

        public VictoryState(IWindowService windowService, IAudioService audioService)
        {
            _windowService = windowService;
            _audioService = audioService;
        }
        
        public void Exit()
        {
        }

        public void Enter()
        {
            _audioService.StopMusic();
            _audioService.PlaySfx(SfxType.Win);
            _windowService.Open(WindowId.Victory);
        }
    }
}