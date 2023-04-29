using System.Collections.Generic;
using Assets.Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services.Factories
{
    public interface IEnemyFactory
    {
        Dictionary<EnemyType, GameObject> Prefabs { get; set; }
        Enemy.Enemy CreateEnemy(GameObject prefab, Vector3 at, Quaternion rotation, Transform parent);
    }
}