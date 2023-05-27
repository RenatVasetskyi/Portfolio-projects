using Assets.Scripts.Car;
using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class Magnet : Booster
    {
        [SerializeField] private float _duration;

        private CarCoinsCollider _coinsCollider;

        private void OnTriggerEnter2D(Collider2D other)
        {
            _coinsCollider = other.GetComponentInChildren<CarCoinsCollider>();
            Take();
            Destroy(gameObject);
        }

        protected override void Take() =>
            _coinsCollider.StartMagnetizing(new Vector2(_points, _points), _duration);
    }
}