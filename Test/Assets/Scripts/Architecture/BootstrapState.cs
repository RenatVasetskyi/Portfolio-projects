using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.States;
using Unity.VisualScripting;
using UnityEngine;
using StateMachine = Assets.Scripts.Architecture.States.StateMachine;

namespace Assets.Scripts.Architecture
{
    public class BootstrapState : IState
    {
        private readonly GameBootstrapper _gameBootstrapper;
        private readonly StateMachine _stateMachine;
        private readonly AllServices _services;

        public BootstrapState(GameBootstrapper gameBootstrapper, StateMachine stateMachine, AllServices allServices)
        {
            _gameBootstrapper = gameBootstrapper;
            _stateMachine = stateMachine;
            _services = allServices;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            RegisterServices();
            _stateMachine.Enter<LoadGameState>();
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<ISceneLoader>(new SceneLoader(_gameBootstrapper));
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IMainFactory>(new MainFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<IStateMachine>(_stateMachine);
        }
    }
}
