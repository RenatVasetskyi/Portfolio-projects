using System;
using Assets.Scripts.Enemy.Animation;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public event Action OnDamageTaken;
        public event Action OnDied;

        [SerializeField] private Enemy _enemy;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private EnemyMovement _enemyMovement;

        private int _maxHp;
        private int _minHp;
        private int _currentHp;

        public void TakeDamage(int damage)
        {
            _currentHp -= damage;
            OnDamageTaken?.Invoke();

            CheckDeath();
        }

        private void Awake() =>
            Init();

        private void Init()
        {
            _maxHp = _enemy.EnemyData.MaxHp;
            _currentHp = _maxHp;
            _minHp = 0;
        }

        private void CheckDeath()
        {
            if (_currentHp <= _minHp)
                Die();
        }

        private void Die()
        {
            _enemyMovement.enabled = false;
            _enemyAnimator.PlayDeath();
            Destroy(gameObject);
            OnDied?.Invoke();
        }
    }
}