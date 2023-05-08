using Assets.Scripts.Architecture.Services.Factories.Enemy;
using Assets.Scripts.Architecture.Services.Factories.UI;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Audio;
using Assets.Scripts.Waves;

namespace Assets.Scripts.Architecture.States
{
    public class GameOverState : IState
    {
        private readonly ILevelUIFactory _levelUIFactory;
        private readonly IWaveSystem _waveSystem;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IAudioService _audioService;

        public GameOverState(ILevelUIFactory levelUIFactory, IWaveSystem waveSystem, IEnemyFactory enemyFactory, IAudioService audioService)
        {
            _levelUIFactory = levelUIFactory;
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
            _levelUIFactory.CreateGameOverWindow();
        }
    }
}