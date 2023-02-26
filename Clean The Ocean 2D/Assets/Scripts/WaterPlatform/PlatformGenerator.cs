using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private WaterPlatform[] _platformPrefabs;
    [SerializeField] private WaterPlatform _firstPlatform;

    private List<WaterPlatform> _spawnedPlatforms = new List<WaterPlatform>();

    private float _playerOffset = 15;

    private float _maxPlatforms = 3;

    private void Start()
    {
        _spawnedPlatforms.Add(_firstPlatform);
    }

    private void Update()
    {
        if (_player.position.y > _spawnedPlatforms[_spawnedPlatforms.Count - 1].End.position.y - _playerOffset)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        WaterPlatform waterPlatform = Instantiate(_platformPrefabs[Random.Range(0, _platformPrefabs.Length)]);
        Vector3 platformOffset = new Vector3(_spawnedPlatforms[_spawnedPlatforms.Count - 1].End.position.x, -45, _spawnedPlatforms[_spawnedPlatforms.Count - 1].End.position.z);
        waterPlatform.transform.position = _spawnedPlatforms[_spawnedPlatforms.Count - 1].End.position - platformOffset;
        _spawnedPlatforms.Add(waterPlatform);

        if (_spawnedPlatforms.Count >= _maxPlatforms)
        {
            Destroy(_spawnedPlatforms[0].gameObject);
            _spawnedPlatforms.RemoveAt(0);
        }
    }
}
