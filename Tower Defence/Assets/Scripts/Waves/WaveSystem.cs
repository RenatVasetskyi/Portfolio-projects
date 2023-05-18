using System;
using System.Collections;
using Assets.Scripts.Architecture.Services.Factories.Enemies;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Enemy.Main;
using Assets.Scripts.Victory;
using UnityEngine;

namespace Assets.Scripts.Waves
{
    public class WaveSystem : IWaveSystem
    {
        private readonly ICheckVictory _victoryChecker;
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;
        private readonly IEnemyFactory _enemyFactory;
        private readonly ICoroutineRunner _coroutineRunner;

        public event Action<int> OnWaveNumberChanged;

        public Coroutine WaveCoroutine;

        public WaveSystem(ICheckVictory victoryChecker, ICurrentLevelSettingsProvider currentLevelSettingsProvider, 
            IEnemyFactory enemyFactory, ICoroutineRunner coroutineRunner)
        {
            _victoryChecker = victoryChecker;
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
                                .GetCurrentLevelSettings().SpawnPoint, Quaternion.identity, _enemyFactory.EnemyParent, enemySpawnData.MaxHp, enemySpawnData.Speed, enemySpawnData.KillBonus);

                            yield return new WaitForSeconds(enemyOnWaveData.TimeDelayBetweenSpawns);
                        }
                    }
                }
            }
            
            _coroutineRunner.StartCoroutine(_victoryChecker.Check());
        }
    }
}