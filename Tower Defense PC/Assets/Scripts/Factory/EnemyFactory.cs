using Enemy;
using System.Collections.Generic;
using System;
using UnityEngine;
using Wave;
using System.Collections;
using Zenject;

public class EnemyFactory : MonoBehaviour, IEnemyFactory
{
    public WaveDescription WaveDescription;

    public event Action<int> OnWaveNumberChange;

    [SerializeField] private Transform _startPoint; 

    [SerializeField] private GameObject _skeletonPrefab;
    [SerializeField] private GameObject _goblinPrefab;

    [SerializeField] private Dictionary<EnemyType, GameObject> _prefabs;

    [SerializeField] private UIWave _startWaveButton;

    private DiContainer _diContainer;

    [Inject]
    private void Construct(DiContainer diContainer)
    {
        _diContainer = diContainer;      
        Initialize();
        _startWaveButton.OnStartWave += StartCreation;
    }

    public void Initialize()
    {
        _prefabs = new Dictionary<EnemyType, GameObject>()
        {
            {EnemyType.Skeleton, _skeletonPrefab},
            {EnemyType.Goblin, _goblinPrefab}
        };       
    }

    public IEnumerator Create()
    {
        foreach (var waveData in WaveDescription.WaveDatas)
        {
            foreach (var enemyOnWaveData in waveData.EnemyDatas)
            {
                yield return new WaitForSeconds(enemyOnWaveData.TimeDelayBetweenWaves);

                OnWaveNumberChange?.Invoke(waveData.WaveNumber);

                foreach (var enemySpawnData in enemyOnWaveData.EnemySpawnDatas)
                {
                    for (int i = 0; i < enemySpawnData.EnemyCount; i++)
                    {
                        _diContainer.InstantiatePrefab(_prefabs[enemySpawnData.Enemy], _startPoint.position, _startPoint.rotation, transform);
                        yield return new WaitForSeconds(enemyOnWaveData.TimeDelayBetweenSpawns);
                    }
                }
            }
        }
    }

    private void OnDestroy()
    {
        _startWaveButton.OnStartWave -= StartCreation;
    }

    private void StartCreation()
    {
        StartCoroutine(Create());      
    } 
}
