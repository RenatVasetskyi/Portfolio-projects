using Assets.Scripts.EnemyPath;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private Finish _finish;
        
        [Inject]
        public void Construct(Finish finish) =>
            _finish = finish;

        public void Start() =>
            _agent.SetDestination(_finish.transform.position);
    }
}