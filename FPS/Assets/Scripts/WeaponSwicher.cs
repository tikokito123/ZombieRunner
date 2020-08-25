using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class WeaponSwicher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }
    void Update()
    {
        int previousWeapon = currentWeapon;
        ProcessKey();
        ProcessControlWheel();
        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }
    private void ProcessControlWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
    }
    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
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
    private void ProcessKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentWeapon = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentWeapon = 4;
        }
    }
}
