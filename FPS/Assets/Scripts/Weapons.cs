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
    [SerializeField] GameObject explosion;
    [SerializeField] Ammo ammoSlot;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammoSlot.GetAmmo() > 0)
            {
                shoot();
            }
            else return;
        }     
    }
    private void Start()
    {
        ammoSlot = FindObjectOfType<Ammo>();
    }

    private void shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
        ammoSlot.ReduceAmmo();
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
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        var expload = Instantiate(explosion, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(expload.gameObject, 0.1f);
    }
}
