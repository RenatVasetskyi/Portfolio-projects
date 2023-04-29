using Assets.Scripts.Architecture.Services.Factories;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Architecture.States
{
    public class LoadLevelState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ILevelUIFactory _levelUIFactory;
        private readonly ILocalCoinService _localCoinService;
        private readonly IPlayerHpService _playerHpService;

        public LoadLevelState(IStateMachine stateMachine, ILevelUIFactory levelUIFactory, ILocalCoinService localCoinService, IPlayerHpService playerHpService)
        {
            _stateMachine = stateMachine;
            _levelUIFactory = levelUIFactory;
            _localCoinService = localCoinService;
            _playerHpService = playerHpService;
            Debug.Log("LoadLevelState");
        }

        public void Exit()
        {
        }

        public void Enter() => 
            OnLoaded();

        private void InitGameWorld()
        {
            _levelUIFactory.CreateLevelUI();
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