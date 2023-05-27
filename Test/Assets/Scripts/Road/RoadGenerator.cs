using System.Collections.Generic;
using Assets.Scripts.Architecture.Services;
using UnityEngine;

namespace Assets.Scripts.Road
{
    public class RoadGenerator : MonoBehaviour
    {
        [SerializeField] private RoadPlatform[] _roadPrefabs;
        [SerializeField] private RoadPlatform _firstPlatform;

        private Transform _player;

        private List<RoadPlatform> _spawnedPlatforms = new();

        private float _playerOffset = 35;
        private float _maxPlatforms = 5;

        private void Start()
        {
            _firstPlatform = Instantiate(_firstPlatform, Vector2.zero, Quaternion.identity);
            _spawnedPlatforms.Add(_firstPlatform);
            _player = AllServices.Container.Single<IMainFactory>().Car;
        }

        private void Update()
        {
            if (_player.position.y > _spawnedPlatforms[_spawnedPlatforms.Count - 1].End.position.y - _playerOffset)
                SpawnPlatform();
        }

        private void SpawnPlatform()
        {
            RoadPlatform road = Instantiate(_roadPrefabs[Random.Range(0, _roadPrefabs.Length)]);
            Vector3 newPosition = new Vector3(0, _spawnedPlatforms[_spawnedPlatforms.Count - 1].End.position.y + (road.SpriteRenderer.bounds.extents.y), 0);
            road.transform.position = newPosition;
            _spawnedPlatforms.Add(road);

            if (_spawnedPlatforms.Count >= _maxPlatforms)
                DestroyLastPlatform();
        }

        private void DestroyLastPlatform()
        {
            Destroy(_spawnedPlatforms[0].gameObject);
            _spawnedPlatforms.RemoveAt(0);
        }
    }
}
