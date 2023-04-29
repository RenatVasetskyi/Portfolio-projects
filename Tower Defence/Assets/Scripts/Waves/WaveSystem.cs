using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Architecture.Services.Factories;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Data;
using UnityEngine;
using Assets.Scripts.Enemy;
using Assets.Scripts.EnemyPath;

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

        public WaveSystem(ICurrentLevelSettingsProvider currentLevelSettingsProvider,
            StartPoint startPoint, IAssetProvider assetProvider, 
            IEnemyFactory enemyFactory, ICoroutineRunner coroutineRunner)
        {
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
            _startPoint = startPoint;
            _assetProvider = assetProvider;
            _enemyFactory = enemyFactory;
            _coroutineRunner = coroutineRunner;
        }

        public void RunStartWaveCoroutine() =>
            _coroutineRunner.StartCoroutine(StartWave());

        private IEnumerator StartWave()
        { 
            Transform parent = Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.EnemyParent));

            foreach (var waveData in _currentLevelSettingsProvider.GetCurrentLevelSettings().WaveSettings.WaveDatas)
            {
                foreach (var enemyOnWaveData in waveData.EnemyDatas)
                {
                    yield return new WaitForSeconds(enemyOnWaveData.TimeDelayBetweenWaves);

                    foreach (var enemySpawnData in enemyOnWaveData.EnemySpawnDatas)
                    {
                        for (int i = 0; i < enemySpawnData.EnemyCount; i++)
                        {
                            _enemyFactory.CreateEnemy(_enemyFactory.Prefabs[enemySpawnData.Enemy], _startPoint.transform.position, Quaternion.identity, parent);
                            yield return new WaitForSeconds(enemyOnWaveData.TimeDelayBetweenSpawns);
                        }
                    }
                }
            }
        }
    }
}