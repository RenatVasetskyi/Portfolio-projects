using Assets.Scripts.Enemy.Animation;
using Assets.Scripts.Enemy.Path;
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