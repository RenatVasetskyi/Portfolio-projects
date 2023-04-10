using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [System.Serializable]
    public class EnemyData
    {
        [SerializeField] private List<EnemySpawnData> _enemySpawnDatas = new List<EnemySpawnData>();
        [SerializeField] private float _timeDelayBetweenWaves;
        [SerializeField] private float _timeDelayBetweenSpawns;

        public List<EnemySpawnData> EnemySpawnDatas => _enemySpawnDatas;
        public float TimeDelayBetweenWaves => _timeDelayBetweenWaves;
        public float TimeDelayBetweenSpawns => _timeDelayBetweenSpawns;
    }
}
