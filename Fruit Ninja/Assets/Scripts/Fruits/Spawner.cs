using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("Fruit")]
    [SerializeField] private Transform _parent;

    [SerializeField] private List<GameObject> _fruitPrefabs;
      
    [SerializeField] private float _minSpeed = 25f;
    [SerializeField] private float _maxSpeed = 30f;

    [SerializeField] private float _minAngle = -10f;
    [SerializeField] private float _maxAngle = 10;
      
    [SerializeField] private float _levelStartDelay = 3f;
    [SerializeField] private float _minSpawnDelay = 0.3f;
    [SerializeField] private float _maxSpawnDelay = 1.5f;

    [SerializeField] private float _maxLifeTime = 6f;

    [Header("Bomb")]
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private float _bombChance = 0.05f;

    private Collider _spawnZone;

    private void Awake()
    {
        _spawnZone = GetComponent<Collider>();
        Events.OnGameOver.AddListener(StopAllCoroutines);
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_levelStartDelay);

        while (enabled)
        {           
            GameObject prefab = _fruitPrefabs[Random.Range(0, _fruitPrefabs.Count)];

            if (Random.value < _bombChance)
            {
                prefab = _bombPrefab;
            }

            Vector3 position = new Vector3();
            position.x = Random.Range(_spawnZone.bounds.min.x, _spawnZone.bounds.max.x);
            position.y = Random.Range(_spawnZone.bounds.min.y, _spawnZone.bounds.max.y);
            position.z = Random.Range(_spawnZone.bounds.min.z, _spawnZone.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(_minAngle, _maxAngle));

            GameObject fruit = Instantiate(prefab, position, rotation, _parent);
            Destroy(fruit, _maxLifeTime);

            float force = Random.Range(_minSpeed, _maxSpeed);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);               

            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
        }
    }
}
