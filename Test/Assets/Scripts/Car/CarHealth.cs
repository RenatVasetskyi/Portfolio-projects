using UnityEngine;

namespace Assets.Scripts.Car
{
    public class CarHealth : MonoBehaviour
    {
        public delegate void HealthChange(float health);
        public HealthChange OnHealthChanged { get; set; }
        public float Health;
    }
}