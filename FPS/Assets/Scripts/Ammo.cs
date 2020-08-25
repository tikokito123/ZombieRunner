using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 30;

    public int GetAmmo()
    {
        return ammoAmount;
    }
    public void ReduceAmmo()
    {
        ammoAmount--;
    }
}
