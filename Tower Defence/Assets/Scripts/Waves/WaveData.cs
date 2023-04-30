using System;
using System.Collections.Generic;
using Assets.Scripts.Enemy.Main;
using UnityEngine;

namespace Assets.Scripts.Waves
{
    [Serializable]
    public class WaveData
    {
        [SerializeField] private int _waveNumber;
        [SerializeField] private List<EnemyOnWaveData> _enemyOnWaveDatas = new List<EnemyOnWaveData>();

        public int WaveNumber => _waveNumber;
        public List<EnemyOnWaveData> EnemyDatas => _enemyOnWaveDatas;
    }
}