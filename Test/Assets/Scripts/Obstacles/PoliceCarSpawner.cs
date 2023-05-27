using System.Collections;
using Assets.Scripts.Architecture.Services;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    public class PoliceCarSpawner : MonoBehaviour
    {
        private float _spawnDelay = 10f;

        private IMainFactory _mainFactory;
        private Vector3 _offset = new Vector3(0, -5, 0);

        private void Awake()
        {
            _mainFactory = AllServices.Container.Single<IMainFactory>();
            StartCoroutine(SpawnCar());
        }

        private IEnumerator SpawnCar()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);
                PoliceCar policeCar = _mainFactory.CreatePoliceCar(_mainFactory.Car.transform.position + _offset);
                StartCoroutine(DestroyCar(policeCar));
            }
        }

        private IEnumerator DestroyCar(PoliceCar car)
        {
            yield return new WaitForSeconds(car.LifeTime);
            Destroy(car.gameObject);
        }
    }
}