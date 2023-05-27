using System;
using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.States;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Car
{
    public class CarHealth : MonoBehaviour
    {
        private const int MinHealth = 0;

        public event Action OnHealthChanged;

        [SerializeField] private float _health;
        private HealthBar _healthBar;

        public float Health => _health;

        private void Start()
        {
            _healthBar = AllServices.Container
                .Single<IMainFactory>().CarControlView.GetComponentInChildren<HealthBar>();
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
            OnHealthChanged?.Invoke();
            CheckDeath();
        }

        public void GetHealth(float health)
        {
            _health += health;
            CheckMaxHealth();
            OnHealthChanged?.Invoke();
        }

        private void CheckMaxHealth()
        {
            if (_health > _healthBar.Fill.maxValue)
                _health = _healthBar.Fill.maxValue;
        }

        private void CheckDeath()
        {
            if (_health <= MinHealth)
                AllServices.Container.Single<IStateMachine>().Enter<GameOverState>();
        }
    }
}