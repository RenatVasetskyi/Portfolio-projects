using Assets.Scripts.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Architecture.Factories
{
    public interface IEnemyFactory
    {
        Dictionary<EnemyType, GameObject> Prefabs { get; set; }
        Enemy CreateEnemy(GameObject prefab, Vector3 at, Quaternion rotation, Transform parent);
    }
}