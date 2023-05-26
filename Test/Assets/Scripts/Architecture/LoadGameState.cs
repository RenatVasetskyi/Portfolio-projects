using Assets.Scripts.Architecture.Services;
using UnityEngine;

namespace Assets.Scripts.Architecture
{
    public class LoadGameState : IState
    {
        private const string GameScene = "Game"; 

        private readonly AllServices _allServices;
        private IMainFactory _mainFactory;
        private ISceneLoader _sceneLoader;

        public LoadGameState(AllServices allServices) =>
            _allServices = allServices;

        public void Exit()
        {
        }

        public void Enter()
        {
            _sceneLoader = _allServices.Single<ISceneLoader>();
            _mainFactory = _allServices.Single<IMainFactory>();
            _sceneLoader.Load(GameScene, InitializeGameWorld);
        }

        private void InitializeGameWorld()
        {
            _mainFactory.CreateStartGameView();
            _mainFactory.CreateCarControlView();
            _mainFactory.CreateCar(Vector2.zero);
            _mainFactory.CreateCamera();
            _mainFactory.CreateCoinsView();
        }
    }
}