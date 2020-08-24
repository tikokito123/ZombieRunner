using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public void PlayerHit(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            print("dead!");
        }
    }
}
