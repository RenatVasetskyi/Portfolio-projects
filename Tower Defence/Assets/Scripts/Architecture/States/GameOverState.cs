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
        private readonly IUIFactory _uiFactory;
        private readonly IWaveSystem _waveSystem;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IAudioService _audioService;

        public GameOverState(IUIFactory uiFactory, IWaveSystem waveSystem, IEnemyFactory enemyFactory, IAudioService audioService)
        {
            _uiFactory = uiFactory;
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
            _uiFactory.CreateGameOverWindow();
        }
    }
}