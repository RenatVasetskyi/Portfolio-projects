using System;
using UnityEngine;

namespace Assets.Scripts.Enemy.Main
{
    [Serializable]
    public class EnemySpawnData
    {
        [SerializeField] private EnemyType _enemy;
        [SerializeField] private int _enemyCount;

        public EnemyType Enemy => _enemy;
        public int EnemyCount => _enemyCount;
    }
}