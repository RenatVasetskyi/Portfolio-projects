using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Data;
using Assets.Scripts.Obstacles;
using Assets.Scripts.Road;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Architecture
{
    public class LoadGameState : IState
    {
        private const string GameScene = "Game"; 

        private readonly AllServices _allServices;
        private IMainFactory _mainFactory;
        private ISceneLoader _sceneLoader;
        private ICoinService _coinService;

        public LoadGameState(AllServices allServices) =>
            _allServices = allServices;

        public void Exit()
        {
        }

        public void Enter()
        {
            _sceneLoader = _allServices.Single<ISceneLoader>();
            _mainFactory = _allServices.Single<IMainFactory>();
            _coinService = _allServices.Single<ICoinService>();
            _sceneLoader.Load(GameScene, InitializeGameWorld);
        }

        private void InitializeGameWorld()
        {
            _coinService.ResetCoins();
            _mainFactory.CreateStartGameView();
            _mainFactory.CreateCarControlView();
            _mainFactory.CreateCar(Vector2.zero);
            _mainFactory.CreateBaseComponent<UnityEngine.Camera>(AssetPath.Camera);
            _mainFactory.CreateBaseComponent<CoinView>(AssetPath.CoinsView, _mainFactory.CreateUIRoot());
            _mainFactory.CreateBaseComponent<RoadGenerator>(AssetPath.RoadGenerator);
            _mainFactory.CreateBaseComponent<PoliceCarSpawner>(AssetPath.PoliceCarSpawner);
        }
    }
}