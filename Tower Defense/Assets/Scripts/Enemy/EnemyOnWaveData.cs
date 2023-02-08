using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyOnWaveData
{   
    [SerializeField] private List<EnemySpawnData> _enemySpawnDatas = new List<EnemySpawnData>();
    [SerializeField] private float _timeDelay;

    public List<EnemySpawnData> EnemySpawnDatas => _enemySpawnDatas;
    public float TimeDelay => _timeDelay;
}
