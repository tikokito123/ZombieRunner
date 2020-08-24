using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera fpCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem muzzleFlash;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }     
    }

    private void shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        var hitEnemies = Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, range);
        if (hitEnemies)
        {
            print("hit " + hit.transform.name);
            // TODO: add particle effect
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }
}
