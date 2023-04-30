using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy.Main
{
    [Serializable]
    public class EnemyOnWaveData
    {
        [SerializeField] private List<EnemySpawnData> _enemySpawnDatas = new List<EnemySpawnData>();
        [SerializeField] private float _timeDelayBetweenWaves;
        [SerializeField] private float _timeDelayBetweenSpawns;

        public List<EnemySpawnData> EnemySpawnDatas => _enemySpawnDatas;
        public float TimeDelayBetweenWaves => _timeDelayBetweenWaves;
        public float TimeDelayBetweenSpawns => _timeDelayBetweenSpawns;
    }
}