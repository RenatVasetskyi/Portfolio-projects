using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _agent;

    private IEnemyMovement _enemyMovement;

    private void Awake()
    {
        _enemyMovement = GetComponent<IEnemyMovement>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _enemyMovement.Move(_agent);
    }
}
