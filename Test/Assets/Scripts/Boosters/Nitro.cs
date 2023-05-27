using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Car;
using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class Nitro : Booster
    {
        [SerializeField] private float _duration;

        private CarMovement _carMovement;

        private void OnTriggerEnter2D(Collider2D other)
        {
            _carMovement = other.GetComponent<CarMovement>();
            Take();
            Destroy(gameObject);
        }

        protected override void Take() =>
            _carMovement.StartBoost(_points, _duration);
    }
}