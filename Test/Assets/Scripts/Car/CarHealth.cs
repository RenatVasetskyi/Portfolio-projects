using System;
using System.Collections;
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
        [SerializeField] private BoxCollider2D _boxCollider;
        private HealthBar _healthBar;

        public float Health => _health;

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

        public void StartBoost(float duration) =>
            StartCoroutine(Boost(duration));

        private void Start()
        {
            _healthBar = AllServices.Container
                .Single<IMainFactory>().CarControlView.GetComponentInChildren<HealthBar>();
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

        private IEnumerator Boost(float duration)
        {
            _boxCollider.enabled = false;
            yield return new WaitForSeconds(duration);
            _boxCollider.enabled = true;
        }
    }
}