using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwicher : MonoBehaviour
{
    [SerializeField] int currentweapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentweapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
    void Update()
    {
        
    }
}
