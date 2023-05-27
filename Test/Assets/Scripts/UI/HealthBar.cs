using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Car;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        public Slider Fill;

        private CarHealth _carHealth;

        private void Start()
        {
            _carHealth = AllServices.Container.Single<IMainFactory>().Car.GetComponent<CarHealth>();

            _carHealth.OnHealthChanged += UpdateHealthBar;
            Fill.maxValue = _carHealth.Health;
            UpdateHealthBar();
        }

        private void UpdateHealthBar() =>
            Fill.value = _carHealth.Health;
    }
}