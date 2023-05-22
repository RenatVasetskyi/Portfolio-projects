using System.Collections.Generic;
using Assets.Scripts.Enemy.Main;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services.Factories.Enemies
{
    public interface IEnemyFactory
    {
        Dictionary<EnemyType, GameObject> Prefabs { get; }
        EnemyParent EnemyParent { get; }
        void CreateEnemy(GameObject prefab, Vector3 at, Quaternion rotation, EnemyParent parent, int maxHp, float speed, int killBonus);
        void CreateEnemyParent();
    }
}