using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Enemy.Animation;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Assets.Scripts.Enemy.Movement
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Main.Enemy _enemy;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private EnemyAnimator _animator;

        private ICurrentLevelSettingsProvider _currentLevelSettingsProvider;

        [Inject]
        public void Construct(ICurrentLevelSettingsProvider currentLevelSettingsProvider) =>
            _currentLevelSettingsProvider = currentLevelSettingsProvider;

        private void Start()
        {
            Initialize();
            _agent.SetDestination(_currentLevelSettingsProvider.GetCurrentLevelSettings().FinishPoint);
        }

        private void Initialize() =>
            _agent.speed = _enemy.Speed;
    }
}