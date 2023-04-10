using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Wave
{
    [System.Serializable]
    public class WaveData
    {
        [SerializeField] private int _waveNumber;
        [SerializeField] private List<EnemyData> _enemyDatas = new List<EnemyData>();

        public int WaveNumber => _waveNumber;
        public List<EnemyData> EnemyDatas => _enemyDatas;
    }
}
