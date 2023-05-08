using System;
using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Audio;
using Assets.Scripts.Enemy.Animation;
using Assets.Scripts.Enemy.Main;
using Assets.Scripts.Enemy.Movement;
using UnityEngine;
using Zenject;

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

        private ILocalCoinService _localCoinService;
        private IAudioService _audioService;

        public int CurrentHp { get; private set; }

        [Inject]
        public void Construct(ILocalCoinService localCoinService, IAudioService audioService)
        {
            _localCoinService = localCoinService;
            _audioService = audioService;
        }

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
            _audioService.PlaySfx(SfxType.EnemyDeath);
            _audioService.PlaySfx(SfxType.GetCoins);
            _localCoinService.GetBonus(_enemy.EnemyData.KillBonus);
            GetComponentInParent<EnemyParent>().Enemies.Remove(gameObject);
            _enemyMovement.enabled = false;
            _enemyAnimator.PlayDeath();
            Destroy(gameObject);
            OnDied?.Invoke();
        }
    }
}