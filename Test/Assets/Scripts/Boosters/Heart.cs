using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Car;
using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class Heart : Booster
    {
        private void OnTriggerEnter2D(Collider2D other) =>
            Take();

        protected override void Take()
        {
            CarHealth carHealth = AllServices.Container
                .Single<IMainFactory>().Car.GetComponent<CarHealth>();

            carHealth.GetHealth(_points);
            Destroy(gameObject);
        }
    }
}