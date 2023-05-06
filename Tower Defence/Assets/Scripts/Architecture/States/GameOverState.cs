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

        public GameOverState(ILevelUIFactory levelUIFactory, IWaveSystem waveSystem)
        {
            _levelUIFactory = levelUIFactory;
            _waveSystem = waveSystem;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _waveSystem.StopWavesCoroutine();
            _levelUIFactory.CreateGameOverWindow();
        }
    }
}