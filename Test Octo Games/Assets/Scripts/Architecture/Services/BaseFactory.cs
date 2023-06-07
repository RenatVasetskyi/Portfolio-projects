using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data;
using Assets.Scripts.Player;
using Assets.Scripts.Weapons;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Services
{
    public class BaseFactory : IBaseFactory
    {
        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;

        public PlayerHealth Player { get; private set; }
        public PistolHolder PistolHolder { get; private set; }

        public BaseFactory(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
        }

        public Transform CreateBaseObjectWithObject(string path) =>
            Object.Instantiate(_assetProvider.Initialize<Transform>(path));

        public T CreateBaseObjectWithContainer<T>(string path, Transform parent) where T : Component =>
            _container.InstantiatePrefabForComponent<T>(_assetProvider.Initialize<T>(path), parent);

        public void CreatePlayer()
        {
            Transform parent = Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.PlayerParent));

            Player = _container.InstantiatePrefabForComponent<PlayerHealth>(_assetProvider.Initialize<GameObject>(AssetPath.Player), parent);
            PistolHolder = Player.GetComponentInChildren<PistolHolder>();
        }
    }
}