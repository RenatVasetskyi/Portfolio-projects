using Assets.Scripts.Architecture.Services.Factories.Main;
using Assets.Scripts.Architecture.Services.Factories.UI;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.UI.Loading;

namespace Assets.Scripts.Architecture.States
{
    public class InitializeGameWorldState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ILevelUIFactory _levelUIFactory;
        private readonly ILocalCoinService _localCoinService;
        private readonly IPlayerHpService _playerHpService;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IMainLevelFactory _mainLevelFactory;

        public InitializeGameWorldState(IStateMachine stateMachine, ILevelUIFactory levelUIFactory, 
            ILocalCoinService localCoinService, IPlayerHpService playerHpService,
            LoadingCurtain loadingCurtain, IMainLevelFactory mainLevelFactory)
        {
            _stateMachine = stateMachine;
            _levelUIFactory = levelUIFactory;
            _localCoinService = localCoinService;
            _playerHpService = playerHpService;
            _loadingCurtain = loadingCurtain;
            _mainLevelFactory = mainLevelFactory;
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
            _mainLevelFactory.InstantiateComponents();
            _levelUIFactory.CreateLevelUI();
            _localCoinService.SetCoins();
            _playerHpService.SetHp();
        }
    }
}