using Assets.Scripts.Car.UI;
using Assets.Scripts.Data;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    public class MainFactory : IMainFactory
    {
        private readonly IAssetProvider _assetProvider;

        public StartGame StartGameView { get; private set; }
        public CarControlView CarControlView { get; private set; }
        public Transform Car { get; private set; }

        public MainFactory(IAssetProvider assetProvider) =>
            _assetProvider = assetProvider;

        public void CreateCar(Vector2 at) =>
            Car = Object.Instantiate(_assetProvider.Initialize<GameObject>(AssetPath.Car), at, Quaternion.identity).transform;

        public void CreateCarControlView() =>
            CarControlView = Object
                .Instantiate(_assetProvider
                    .Initialize<CarControlView>(AssetPath.CarControlView))
                .GetComponent<CarControlView>();
        
        public void CreateStartGameView() =>
            StartGameView = Object
                .Instantiate(_assetProvider
                    .Initialize<StartGame>(AssetPath.StartGameView))
                .GetComponent<StartGame>();

        public void CreateBaseComponent<T>(string path) where T : Component =>
            Object.Instantiate(_assetProvider
                .Initialize<T>(path));

        public void CreateBaseComponent<T>(string path, Transform parent) where T : Component =>
            Object.Instantiate(_assetProvider
                .Initialize<T>(path), parent);

        public Transform CreateUIRoot() =>
            Object.Instantiate(_assetProvider
                .Initialize<Transform>(AssetPath.UIRoot).transform);
    }
}