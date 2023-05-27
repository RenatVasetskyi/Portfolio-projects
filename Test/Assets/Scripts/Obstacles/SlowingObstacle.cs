using System.Collections;
using Assets.Scripts.Car;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    public class SlowingObstacle : Obstacle
    {
        public float Slowing;
        public float SlowingDuration;

        private void OnTriggerEnter2D(Collider2D other)
        {
            CarHealth carHealth = other.GetComponent<CarHealth>();
            GiveDamage(carHealth, _damage);
            StartCoroutine(Slow(other.GetComponent<CarMovement>()));
        }

        private IEnumerator Slow(CarMovement carMovement)
        {
            carMovement.MaxSpeed /= Slowing;
            yield return new WaitForSeconds(SlowingDuration);
            carMovement.MaxSpeed *= Slowing;
        }
    }
}