using System.Collections.Generic;
using Assets.Scripts.Enemy.Main;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services.Factories.Enemy
{
    public interface IEnemyFactory
    {
        Dictionary<EnemyType, GameObject> Prefabs { get; set; }
        GameObject CreateEnemy(GameObject prefab, Vector3 at, Quaternion rotation, Transform parent);
    }
}