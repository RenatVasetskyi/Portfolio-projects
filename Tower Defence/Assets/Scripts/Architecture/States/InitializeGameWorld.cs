using Assets.Scripts.Architecture.Services.Factories;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.UI.Loading;

namespace Assets.Scripts.Architecture.States
{
    public class InitializeGameWorld : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ILevelUIFactory _levelUIFactory;
        private readonly ILocalCoinService _localCoinService;
        private readonly IPlayerHpService _playerHpService;
        private readonly LoadingCurtain _loadingCurtain;

        public InitializeGameWorld(IStateMachine stateMachine, ILevelUIFactory levelUIFactory, ILocalCoinService localCoinService, IPlayerHpService playerHpService, LoadingCurtain loadingCurtain)
        {
            _stateMachine = stateMachine;
            _levelUIFactory = levelUIFactory;
            _localCoinService = localCoinService;
            _playerHpService = playerHpService;
            _loadingCurtain = loadingCurtain;
        }

        public void Exit() =>
            _loadingCurtain.Hide();

        public void Enter()
        {
            InitGameWorld();
            _stateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            _levelUIFactory.CreateLevelUI();
            _localCoinService.SetCoins();
            _playerHpService.SetHp();
        }
    }
}