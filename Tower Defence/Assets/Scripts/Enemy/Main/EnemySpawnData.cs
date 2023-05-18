using System;
using UnityEngine;

namespace Assets.Scripts.Enemy.Main
{
    [Serializable]
    public class EnemySpawnData
    {
        [SerializeField] private EnemyType _enemy;
        [SerializeField] private int _enemyCount;
        [SerializeField] private int _maxHp;
        [SerializeField] private int _speed;
        [SerializeField] private int _killBonus;

        public EnemyType Enemy => _enemy;
        public int EnemyCount => _enemyCount;
        public int MaxHp => _maxHp;
        public int Speed => _speed;
        public int KillBonus => _killBonus;
    }
}