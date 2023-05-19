using Assets.Scripts.Architecture.Services.Factories.Enemies;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemy.Health
{
    public class EnemyCollision : MonoBehaviour
    {
        [SerializeField] private Main.Enemy _enemy;

        private IEnemyFactory _enemyFactory;
        private IPlayerHpService _playerHpService;

        [Inject]
        public void Construct(IEnemyFactory enemyFactory, IPlayerHpService playerHpService)
        {
            _enemyFactory = enemyFactory;
            _playerHpService = playerHpService;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Finish))
            {
                _playerHpService.TakeDamage(1);
                _enemyFactory.EnemyParent.Enemies.Remove(_enemy);
                Destroy(gameObject);    
            }
        }
    }
}