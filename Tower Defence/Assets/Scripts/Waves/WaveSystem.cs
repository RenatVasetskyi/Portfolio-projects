using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Architecture.Factories;
using Assets.Scripts.Architecture.Main;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data;
using UnityEngine;
using Assets.Scripts.Enemy;

namespace Assets.Scripts.Waves
{
    public class WaveSystem : IWaveSystem
    {
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;
        private readonly StartPoint _startPoint;
        private readonly IAssetProvider _assetProvider;
        private readonly IEnemyFactory _enemyFactory;
        private readonly ICoroutineRunner _coroutineRunner;

        [SerializeField] private GameObject _skeletonPrefab;
        [SerializeField] private GameObject _goblinPrefab;

        private Dictionary<EnemyType, GameObject> _prefabs;

        public WaveSystem(ICurrentLevelSettingsProvider currentLevelSettingsProvider, StartPoint startPoint, IAssetProvider assetProvider, IEnemyFactory enemyFactory, ICoroutineRunner coroutineRunner)
        {
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
            _startPoint = startPoint;
            _assetProvider = assetProvider;
            _enemyFactory = enemyFactory;
            _coroutineRunner = coroutineRunner;
        }
            
        private IEnumerator StartWave()
        { 
            Transform parent = Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.EnemyParent));

            foreach (var waveData in _currentLevelSettingsProvider.GetCurrentLevelSettings().WaveSettings.WaveDatas)
            {
                foreach (var enemyOnWaveData in waveData.EnemyDatas)
                {
                    yield return new WaitForSeconds(enemyOnWaveData.TimeDelayBetweenWaves);

                    //OnWaveNumberChange?.Invoke(waveData.WaveNumber);

                    foreach (var enemySpawnData in enemyOnWaveData.EnemySpawnDatas)
                    {
                        for (int i = 0; i < enemySpawnData.EnemyCount; i++)
                        {
                            _enemyFactory.CreateEnemy(_prefabs[enemySpawnData.Enemy], _startPoint.transform.position, Quaternion.identity, parent);
                            //_container.InstantiatePrefab(_prefabs[enemySpawnData.Enemy], _startPoint.transform.position, _startPoint.transform.rotation, parent.transform);
                            yield return new WaitForSeconds(enemyOnWaveData.TimeDelayBetweenSpawns);
                        }
                    }
                }
            }
        }

        public void RunStartWaveCoroutine() =>
            _coroutineRunner.StartCoroutine(StartWave());

        //private void OnDestroy()
        //{
        //    _startWaveButton.OnStartWave -= StartCreation;
        //}

        //private void StartCreation()
        //{
        //    StartCoroutine(Create());
        //}
    }
}