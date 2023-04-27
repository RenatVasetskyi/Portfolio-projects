using Assets.Scripts.Architecture.Factories;
using Assets.Scripts.Architecture.Main;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;

namespace Assets.Scripts.Architecture.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly ILocalCoinService _localCoinService;
        private readonly IPlayerHpService _playerHpService;

        public LoadLevelState(IStateMachine stateMachine, ISceneLoader sceneLoader, IUIFactory uiFactory, ILocalCoinService localCoinService, IPlayerHpService playerHpService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _localCoinService = localCoinService;
            _playerHpService = playerHpService;
        }

        public void Exit()
        {
        }

        public void Enter(string nextScene) =>
            _sceneLoader.Load(nextScene, OnLoaded);

        private void InitGameWorld()
        {
            _uiFactory.CreateLevelUI();
            _localCoinService.SetCoins();
            _playerHpService.SetHp();
        }

        private void OnLoaded()
        {
            InitGameWorld();
            _stateMachine.Enter<GameLoopState>();
        }
    }
}