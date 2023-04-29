using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Architecture.Factories
{
    public class Enemy : MonoBehaviour
    {
        private readonly Finish _finish;
        private NavMeshAgent _agent;

        public Enemy(Finish finish) =>
            _finish = finish;

        public void Start() =>
            _agent.SetDestination(_finish.transform.position);
    }
}