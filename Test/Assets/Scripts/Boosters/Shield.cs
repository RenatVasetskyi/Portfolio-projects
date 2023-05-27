using Assets.Scripts.Car;
using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class Shield : Booster
    {
        private CarHealth _carHealth;

        private void OnTriggerEnter2D(Collider2D other)
        {
            _carHealth = other.GetComponentInParent<CarHealth>();
            Take();
            Destroy(gameObject);
        }

        protected override void Take() =>
            _carHealth.StartBoost(_duration);
    }
}