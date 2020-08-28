using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    FlashLight flash;
    [SerializeField] float restoreAngel = 5f;
    [SerializeField] float restoreIntencity = 3.5f;
    void Start()
    {
        flash = FindObjectOfType<FlashLight>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Restore();
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
    private void Restore()
    {
        flash.RestoreAngel(restoreAngel);
        flash.RestoreLightIntensity(restoreIntencity);
    }
}
