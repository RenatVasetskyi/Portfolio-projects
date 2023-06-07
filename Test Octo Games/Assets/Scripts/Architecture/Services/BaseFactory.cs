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

        public BaseFactory(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
        }

        public T CreateBaseObjectWithObject<T>(string path) where T : Component =>
            Object.Instantiate(_assetProvider.Initialize<T>(path));

        public T CreateBaseObjectWithContainer<T>(string path) where T : Component =>
            _container.InstantiatePrefabForComponent<T>(_assetProvider.Initialize<T>(path));

        public T CreateBaseObjectWithContainer<T>(string path, Transform parent) where T : Component =>
            _container.InstantiatePrefabForComponent<T>(_assetProvider.Initialize<T>(path), parent);

        public void CreatePlayer()
        {
            Transform parent = Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.PlayerParent));

            Player = _container.InstantiatePrefabForComponent<PlayerHealth>(_assetProvider.Initialize<GameObject>(AssetPath.Player), parent);
        }
    }
}