using System;
using System.Collections;
using Assets.Scripts.Architecture.Services.Factories.Enemy;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Enemy.Main;
using UnityEngine;

namespace Assets.Scripts.Waves
{
    public class WaveSystem : IWaveSystem
    {
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;
        private readonly IEnemyFactory _enemyFactory;
        private readonly ICoroutineRunner _coroutineRunner;

        public event Action<int> OnWaveNumberChanged;

        public Coroutine WaveCoroutine;

        public WaveSystem(ICurrentLevelSettingsProvider currentLevelSettingsProvider, 
            IEnemyFactory enemyFactory, ICoroutineRunner coroutineRunner)
        {
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
            _enemyFactory = enemyFactory;
            _coroutineRunner = coroutineRunner;
        }

        public void RunStartWaveCoroutine() =>
            WaveCoroutine = _coroutineRunner.StartCoroutine(StartWave());

        public void StopWavesCoroutine() =>
            _coroutineRunner.StopCoroutine(WaveCoroutine);

        private IEnumerator StartWave()
        {
            _enemyFactory.CreateEnemyParent();

            foreach (WaveData waveData in _currentLevelSettingsProvider.GetCurrentLevelSettings().WaveSettings.WaveDatas)
            {
                foreach (EnemyOnWaveData enemyOnWaveData in waveData.EnemyDatas)
                {
                    yield return new WaitForSeconds(enemyOnWaveData.TimeDelayBetweenWaves);

                    OnWaveNumberChanged?.Invoke(waveData.WaveNumber);

                    foreach (EnemySpawnData enemySpawnData in enemyOnWaveData.EnemySpawnDatas)
                    {
                        for (int i = 0; i < enemySpawnData.EnemyCount; i++)
                        {
                            _enemyFactory.CreateEnemy(_enemyFactory.Prefabs[enemySpawnData.Enemy], _currentLevelSettingsProvider
                                .GetCurrentLevelSettings().SpawnPoint, Quaternion.identity, _enemyFactory.EnemyParent);
                            yield return new WaitForSeconds(enemyOnWaveData.TimeDelayBetweenSpawns);
                        }
                    }
                }
            }
        }
    }
}