using System.Collections.Generic;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data;
using Assets.Scripts.Enemy.Main;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Services.Factories.Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;

        public Dictionary<EnemyType, GameObject> Prefabs { get; set; } = new();

        public EnemyFactory(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
            Initialize();
        }

        public GameObject CreateEnemy(GameObject prefab, Vector3 at, Quaternion rotation, Transform parent) =>
            _container.InstantiatePrefab(prefab, at, rotation, parent);

        private void Initialize()
        {
            Prefabs = new Dictionary<EnemyType, GameObject>()
            {
                {EnemyType.Skeleton, _assetProvider.Initialize<GameObject>(AssetPath.SkeletonPrefab)},
                {EnemyType.Goblin, _assetProvider.Initialize<GameObject>(AssetPath.GoblinPrefab)}
            };
        }
    }
}