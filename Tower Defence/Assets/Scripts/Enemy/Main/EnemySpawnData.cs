using System;
using Assets.Scripts.Enemy.Main;
using UnityEngine;

[Serializable]
public class EnemySpawnData
{
    [SerializeField] private EnemyType _enemy;
    [SerializeField] private int _enemyCount;

    public EnemyType Enemy => _enemy;
    public int EnemyCount => _enemyCount;
}