using System;
using Assets.Scripts.Enemy.Animation;
using Assets.Scripts.Enemy.Main;
using Assets.Scripts.Enemy.Movement;
using UnityEngine;

namespace Assets.Scripts.Enemy.Health
{
    public class EnemyHealth : MonoBehaviour
    {
        public event Action OnHealthChanged;
        public event Action OnDied;

        [SerializeField] private Main.Enemy _enemy;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private EnemyMovement _enemyMovement;

        private int _maxHp;
        private int _minHp;

        public int CurrentHp { get; private set; }

        public void TakeDamage(int damage)
        {
            CurrentHp -= damage;
            OnHealthChanged?.Invoke();

            CheckDeath();
        }

        private void Awake() =>
            Init();

        private void Init()
        {
            _maxHp = _enemy.EnemyData.MaxHp;
            CurrentHp = _maxHp;
            _minHp = 0;
        }

        private void CheckDeath()
        {
            if (CurrentHp <= _minHp)
                Die();
        }

        private void Die()
        {
            GetComponentInParent<EnemyParent>().Enemies.Remove(gameObject);
            _enemyMovement.enabled = false;
            _enemyAnimator.PlayDeath();
            Destroy(gameObject);
            OnDied?.Invoke();
        }
    }
}