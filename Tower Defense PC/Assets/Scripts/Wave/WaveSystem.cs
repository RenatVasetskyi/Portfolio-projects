using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using System;

namespace Wave
{
    public class WaveSystem : MonoBehaviour
    {     
        public WaveDescription _waveDescription;

        public event Action<int> OnWaveNumberChange;

        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _parent;

        [SerializeField] private GameObject _skeletonPrefab;
        [SerializeField] private GameObject _goblinPrefab;

        [SerializeField] private Dictionary<EnemyType, GameObject> _prefabs;

        [SerializeField] private UIWave _waveUI;

        private void Awake()
        {
            _waveUI.OnStartWave += StartWaveCoroutine;
        }

        private void OnDestroy()
        {
            _waveUI.OnStartWave -= StartWaveCoroutine;
        }

        private IEnumerator RunWave()
        {
            _prefabs = new Dictionary<EnemyType, GameObject>()
            {
                {EnemyType.Skeleton, _skeletonPrefab},
                {EnemyType.Goblin, _goblinPrefab}
            };

            foreach (var waveData in _waveDescription.WaveDatas)
            {               
                foreach (var enemyOnWaveData in waveData.EnemyOnWaveDatas)
                {                 
                    yield return new WaitForSeconds(enemyOnWaveData.TimeDelayBetweenWaves);

                    OnWaveNumberChange?.Invoke(waveData.WaveNumber);

                    foreach (var enemySpawnData in enemyOnWaveData.EnemySpawnDatas)
                    {
                        for (int i = 0; i < enemySpawnData.EnemyCount; i++)
                        {
                            Instantiate(_prefabs[enemySpawnData.Enemy], _startPoint.position, _startPoint.rotation, _parent);
                            yield return new WaitForSeconds(enemyOnWaveData.TimeDelayBetweenSpawns);
                        }
                    }
                }
            }
        }

        private void StartWaveCoroutine()
        {
            StartCoroutine(RunWave());
        }
    }
}
