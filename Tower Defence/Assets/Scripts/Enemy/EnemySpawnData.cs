using Assets.Scripts.Enemy;
using System;
using UnityEngine;

[Serializable]
public class EnemySpawnData
{
    [SerializeField] private EnemyType _enemy;
    [SerializeField] private int _enemyCount;

    public EnemyType Enemy => _enemy;
    public int EnemyCount => _enemyCount;
}