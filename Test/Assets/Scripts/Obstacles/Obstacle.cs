using Assets.Scripts.Car;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] protected float _damage;

        public void GiveDamage(CarHealth carHealth, float damage) =>
            carHealth.TakeDamage(damage);
    }
}