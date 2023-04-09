using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemyMovement : MonoBehaviour, IMovable
{   
    private NavMeshAgent _agent;

    private Finish _finish;

    [Inject]
    private void Construct(Finish finish)
    {
        _finish = finish;      
    }

    public void Move()
    {
        _agent.SetDestination(_finish.transform.position);
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Move();
    }
}
