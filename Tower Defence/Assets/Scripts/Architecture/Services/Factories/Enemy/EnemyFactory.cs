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
        public EnemyParent EnemyParent { get; private set; }

        public EnemyFactory(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
            InitializeEnemies();
        }

        public GameObject CreateEnemy(GameObject prefab, Vector3 at, Quaternion rotation, EnemyParent parent)
        {
            GameObject enemy = _container.InstantiatePrefab(prefab, at, rotation, parent.transform);
            parent.Enemies.Add(enemy);
            return enemy;
        }

        public void CreateEnemyParent() =>
            EnemyParent = Object.Instantiate(_assetProvider.Initialize<EnemyParent>(AssetPath.EnemyParent));

        private void InitializeEnemies()
        {
            Prefabs = new Dictionary<EnemyType, GameObject>()
            {
                {EnemyType.Skeleton, _assetProvider.Initialize<GameObject>(AssetPath.SkeletonPrefab)},
                {EnemyType.Goblin, _assetProvider.Initialize<GameObject>(AssetPath.GoblinPrefab)}
            };
        }
    }
}