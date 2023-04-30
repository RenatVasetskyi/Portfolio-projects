using Assets.Scripts.Enemy.Animation;
using Assets.Scripts.EnemyPath;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Assets.Scripts.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private EnemyAnimator _animator;

        private Finish _finish;

        [Inject]
        public void Construct(Finish finish) =>
            _finish = finish;

        private void Start()
        {
            Init();
            _agent.SetDestination(_finish.transform.position);
        }

        private void Init() =>
            _agent.speed = _enemy.EnemyData.Speed;
    }
}