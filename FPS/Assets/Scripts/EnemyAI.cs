using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    [SerializeField] float chaseRange = 5f;
    float distanceToTarget = Mathf.Infinity;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        ChaseAfterTarget();
    }

    private void ChaseAfterTarget()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget < chaseRange)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }
}
