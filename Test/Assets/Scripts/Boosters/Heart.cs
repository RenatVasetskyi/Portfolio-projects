using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Car;
using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class Heart : MonoBehaviour
    {
        [SerializeField] private int Points;

        private void OnTriggerEnter2D(Collider2D other) =>
            Take();

        private void Take()
        {
            CarHealth carHealth = AllServices.Container
                .Single<IMainFactory>().Car.GetComponent<CarHealth>();

            carHealth.GetHealth(Points);
            Destroy(gameObject);
        }
    }
}