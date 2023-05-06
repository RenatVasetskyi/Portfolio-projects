using Assets.Scripts.Architecture.Services.Factories.Enemy;
using Assets.Scripts.Architecture.Services.Factories.UI;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Waves;

namespace Assets.Scripts.Architecture.States
{
    public class GameOverState : IState
    {
        private readonly ILevelUIFactory _levelUIFactory;
        private readonly IWaveSystem _waveSystem;
        private readonly IEnemyFactory _enemyFactory;

        public GameOverState(ILevelUIFactory levelUIFactory, IWaveSystem waveSystem, IEnemyFactory enemyFactory)
        {
            _levelUIFactory = levelUIFactory;
            _waveSystem = waveSystem;
            _enemyFactory = enemyFactory;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _waveSystem.StopWavesCoroutine();
            _enemyFactory.EnemyParent.DestroyEnemies();
            _levelUIFactory.CreateGameOverWindow();
        }
    }
}