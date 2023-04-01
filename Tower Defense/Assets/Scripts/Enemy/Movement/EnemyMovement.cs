using UnityEngine;
using UnityEngine.AI;
using Data;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour, IEnemyMovement
    {
        private GameObject _finish;

        public void Move(NavMeshAgent navMeshAgent)
        {
            _finish = GameObject.FindGameObjectWithTag(Constants.FinishTag);
            navMeshAgent.SetDestination(_finish.transform.position);
        }
    }
}
