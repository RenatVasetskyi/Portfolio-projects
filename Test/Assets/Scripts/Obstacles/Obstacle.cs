using Assets.Scripts.Car;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        public float Damage;

        public void GiveDamage(CarHealth carHealth, float damage) =>
            carHealth.Health -= damage;
    }
}