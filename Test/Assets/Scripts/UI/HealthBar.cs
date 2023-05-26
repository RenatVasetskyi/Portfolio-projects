using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Car;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _fill;
        [SerializeField] private CarHealth _carHealth;

        private void Start()
        {
            _carHealth = AllServices.Container.Single<IMainFactory>().Car.GetComponent<CarHealth>();

            _carHealth.OnHealthChanged += UpdateHealthBar;
            _fill.maxValue = _carHealth.Health;
            UpdateHealthBar(_fill.maxValue);
        }

        private void UpdateHealthBar(float hp) =>
            _fill.value = hp;
    }
}