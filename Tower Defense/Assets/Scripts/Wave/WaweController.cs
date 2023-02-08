using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WaweController : MonoBehaviour
{
    [SerializeField] private WaveDescription _waveDescription;

    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _parent;

    [SerializeField] private GameObject _skeleton;
    [SerializeField] private GameObject _goblin;

    [SerializeField] private Dictionary<EnemyType, GameObject> _prefabs;

    [SerializeField] private Button _waveButton;

    private void Awake()
    {      
        _waveButton.onClick.AddListener(OnWaveButtonClickHandler);
    }

    private IEnumerator RunWave()
    {
        _prefabs = new Dictionary<EnemyType, GameObject>()
        {
            {EnemyType.Skeleton, _skeleton},
            {EnemyType.Goblin, _goblin}
        };

        foreach (var waveData in _waveDescription.WaveDatas)
        {
            foreach (var enemyOnWaveData in waveData.EnemyOnWaveDatas)
            {
                yield return new WaitForSeconds(enemyOnWaveData.TimeDelay);

                foreach (var enemySpawnData in enemyOnWaveData.EnemySpawnDatas)
                {
                    for (int i = 0; i < enemySpawnData.EnemyCount; i++)
                    {
                        Instantiate(_prefabs[enemySpawnData.Enemy], _startPoint.position, _startPoint.rotation, _parent);                       
                    }
                }
            }
        }
    }

    private void OnWaveButtonClickHandler()
    {       
        StartCoroutine(RunWave());
    }
}
