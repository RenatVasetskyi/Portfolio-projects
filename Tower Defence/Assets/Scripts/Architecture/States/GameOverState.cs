using Assets.Scripts.Architecture.Services.Factories.Enemy;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Audio;
using Assets.Scripts.Data.Windows;
using Assets.Scripts.Waves;

namespace Assets.Scripts.Architecture.States
{
    public class GameOverState : IState
    {
        private readonly IWindowService _windowService;
        private readonly IWaveSystem _waveSystem;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IAudioService _audioService;

        public GameOverState(IWindowService windowService, IWaveSystem waveSystem, IEnemyFactory enemyFactory, IAudioService audioService)
        {
            _windowService = windowService;
            _waveSystem = waveSystem;
            _enemyFactory = enemyFactory;
            _audioService = audioService;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _audioService.StopMusic();
            _audioService.PlaySfx(SfxType.GameOver);
            _waveSystem.StopWavesCoroutine();
            _enemyFactory.EnemyParent.DestroyEnemies();
            _windowService.Open(WindowId.GameOver);
        }
    }
}