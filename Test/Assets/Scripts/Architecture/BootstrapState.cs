using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.States;
using UnityEngine;

namespace Assets.Scripts.Architecture
{
    public class BootstrapState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly AllServices _services;

        public BootstrapState(StateMachine stateMachine, AllServices allServices)
        {
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
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IMainFactory>(new MainFactory(_services.Single<IAssetProvider>()));
        }
    }
}
