using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Wave
{
    [System.Serializable]
    public class WaveData
    {
        [SerializeField] private int _waveNumber;
        [SerializeField] private List<EnemyOnWaveData> _enemyOnWaveDatas = new List<EnemyOnWaveData>();

        public int WaveNumber => _waveNumber;
        public List<EnemyOnWaveData> EnemyOnWaveDatas => _enemyOnWaveDatas;
    }
}
