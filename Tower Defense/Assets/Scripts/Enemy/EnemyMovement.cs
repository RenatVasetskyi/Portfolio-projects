using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject _finish;

    void Start()
    {       
        _finish = GameObject.FindGameObjectWithTag(Constants.FinishTag);
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_finish.transform.position);
    }
}
