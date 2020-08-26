using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float healthPoints = 100f;
    bool isDead = false;
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            Die();
        }
    }
    public bool IsDead()
    {
        return isDead;
    }
    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }
}
