using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public float fireRate = 15f;
    public float maxAmmo = 6f;
    public float gunAmmo;

    public Camera fpsCam;

    private float nextTimeToFire = 0f;
    public GameObject shot;

    public static event Action OnBulletFired;

    void Start()
    {
        gunAmmo = maxAmmo;
    }
    
    void Update () {
        if ((Input.GetButtonDown("Fire1") || Input.GetAxisRaw("Fire1") > 0)&& Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
            Instantiate(shot);
        }
    }

    void Shoot ()
    {
        RaycastHit hit;
        gunAmmo--;
        OnBulletFired?.Invoke();
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        
    }
    
}
