using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    public float damage = 10f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }
    public void AttackHitEvent()
    {
        if (target == null) return;
        target.PlayerHit(damage);
    }
}
