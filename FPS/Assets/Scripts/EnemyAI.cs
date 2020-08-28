using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    Animator enemyAnimator;
    NavMeshAgent navMeshAgent;
    Transform target;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        target = FindObjectOfType<RigidbodyFirstPersonController>().transform;
    }
    void Update()
    {
        if (GetComponent<EnemyHealth>().IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
            Destroy(gameObject, 10f);
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }

    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseAfterTarget();
        }
        else if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget(); 
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    private void ChaseAfterTarget()
    {
        enemyAnimator.SetBool("Attack", false);
        enemyAnimator.SetTrigger("Move");
        if (navMeshAgent.enabled)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void AttackTarget()
    {
        enemyAnimator.SetBool("Attack", true);
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
    }
    public void OnDamageTaken()
    {
        isProvoked = true;
    }
}
