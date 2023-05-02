using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Services.Factories.Main
{
    public class MainLevelFactory : IMainLevelFactory
    {
        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;

        public MainLevelFactory(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
        }

        public void InstantiateComponents()
        {
           GameObject parent = Object.Instantiate(_assetProvider.Initialize<GameObject>(AssetPath.MainLevelComponentsParent));

            CreateTowerSpawner(parent.transform);
        }

        private void CreateTowerSpawner(Transform parent) =>
            _container.InstantiatePrefab(_assetProvider.Initialize<GameObject>(AssetPath.TowerSpawner));
    }
}
