using System.Collections.Generic;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data;
using Assets.Scripts.Enemy.Main;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Services.Factories.Enemies
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;

        public Dictionary<EnemyType, GameObject> Prefabs { get; private set; }
        public EnemyParent EnemyParent { get; private set; }

        public EnemyFactory(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
            InitializeEnemies();
        }

        public void CreateEnemy(GameObject prefab, Vector3 at, Quaternion rotation, EnemyParent parent, int maxHp, float speed, int killBonus)
        {
            Enemy.Main.Enemy enemy = _container.InstantiatePrefabForComponent<Enemy.Main.Enemy>(prefab, at, rotation, parent.transform);

            enemy.MaxHp = maxHp;
            enemy.Speed = speed;
            enemy.KillBonus = killBonus;

            parent.Enemies.Add(enemy);
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