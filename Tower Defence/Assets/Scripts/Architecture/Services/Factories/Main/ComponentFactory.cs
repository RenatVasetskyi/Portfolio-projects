using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data;
using Assets.Scripts.Tower.Spawn;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Services.Factories.Main
{
    public class ComponentFactory : IComponentFactory
    {
        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;

        public ComponentFactory(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
        }

        public void InstantiateComponents()
        {
            GameObject parent = Object.Instantiate(_assetProvider.Initialize<GameObject>(AssetPath.MainLevelComponentsParent));

            CreateComponent<TowerSpawner>(AssetPath.TowerSpawner, parent.transform);
            CreateComponent<TowerModelDisplayer>(AssetPath.TowerModelDisplayer, parent.transform);
        }

        private void CreateComponent<T>(string componentPath, Transform parent) where T : MonoBehaviour =>
            _container.InstantiatePrefab(_assetProvider.Initialize<T>(componentPath), parent);
    }
}
