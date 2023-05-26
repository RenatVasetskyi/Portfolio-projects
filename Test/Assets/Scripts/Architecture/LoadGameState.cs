using Assets.Scripts.Architecture.Services;
using UnityEngine;

namespace Assets.Scripts.Architecture
{
    public class LoadGameState : IState
    {
        private readonly AllServices _allServices;
        private IMainFactory _mainFactory;

        public LoadGameState(AllServices allServices)
        {
            _allServices = allServices;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _mainFactory = _allServices.Single<IMainFactory>();
            InitializeGameWorld();
        }

        private void InitializeGameWorld()
        {
            _mainFactory.CreateStartGameView();
            _mainFactory.CreateCarControlView();
            _mainFactory.CreateCar(Vector2.zero);
        }
    }
}