using Assets.Scripts.Car;
using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class Nitro : ExtraBooster
    {
        private CarMovement _carMovement;

        private void OnTriggerEnter2D(Collider2D other)
        {
            _carMovement = other.GetComponentInParent<CarMovement>();
            Take();
            Destroy(gameObject);
        }

        protected override void Take() =>
            _carMovement.StartBoost(_points, _duration);
    }
}