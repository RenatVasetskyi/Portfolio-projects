using UnityEngine.AI;

namespace Enemy
{
    public interface IEnemyMovement
    {
        public void Move(NavMeshAgent navMeshAgent);
    }
}
