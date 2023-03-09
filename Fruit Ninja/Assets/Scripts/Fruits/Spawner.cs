using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

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

    private List<GameObject> _spawnedObjects = new List<GameObject>();

    private float _destroyDelay = 1.5f;

    private void Awake()
    {       
        foreach (var obj in _fruitPrefabs)
        {
            obj.GetComponent<Rigidbody>().isKinematic = false;
            obj.GetComponent<Rigidbody>().detectCollisions = false;
            obj.GetComponent<SphereCollider>().enabled = true;          
        }

        _spawnZone = GetComponent<Collider>();
        Events.OnBombExploded.AddListener(StopAllCoroutines);
        Events.OnBombExploded.AddListener(StopObjects);
        Events.OnBombExploded.AddListener(DestroySpawnedObjects);
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
            _spawnedObjects.Add(fruit);
            AudioManager.Instance.PlaySfx(SfxType.TossUp);

            Destroy(fruit, _maxLifeTime);
            StartCoroutine(RemoveObject(fruit));

            float force = Random.Range(_minSpeed, _maxSpeed);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);               

            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
        }
    }

    private void StopObjects()
    {
        foreach (GameObject gameObject in _spawnedObjects)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;           
        }
    }

    private IEnumerator DestroySpawnedObjectsCoroutine()
    {
        yield return new WaitForSeconds(_destroyDelay);

        foreach (GameObject gameObject in _spawnedObjects)
        {
            Destroy(gameObject);
        }
    }

    private void DestroySpawnedObjects()
    {
        StartCoroutine(DestroySpawnedObjectsCoroutine());
    }

    private IEnumerator RemoveObject(GameObject gameObject)
    {
        yield return new WaitForSeconds(_maxLifeTime);
        _spawnedObjects.Remove(gameObject);
    }
}
