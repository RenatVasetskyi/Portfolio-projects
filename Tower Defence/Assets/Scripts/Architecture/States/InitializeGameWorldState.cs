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
        private readonly IUIFactory _uiFactory;
        private readonly ILocalCoinService _localCoinService;
        private readonly IPlayerHpService _playerHpService;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IMainLevelFactory _mainLevelFactory;
        private readonly IAudioService _audioService;
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;

        public InitializeGameWorldState(IStateMachine stateMachine, IUIFactory uiFactory, 
            ILocalCoinService localCoinService, IPlayerHpService playerHpService,
            LoadingCurtain loadingCurtain, IMainLevelFactory mainLevelFactory, IAudioService audioService,
            ICurrentLevelSettingsProvider currentLevelSettingsProvider)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _localCoinService = localCoinService;
            _playerHpService = playerHpService;
            _loadingCurtain = loadingCurtain;
            _mainLevelFactory = mainLevelFactory;
            _audioService = audioService;
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
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
            _audioService.PlayMusic(_currentLevelSettingsProvider.GetCurrentLevelSettings().MusicType);
            _mainLevelFactory.InstantiateComponents();
            _uiFactory.CreateLevelUI();
            _localCoinService.SetCoins();
            _playerHpService.SetHp();
        }
    }
}