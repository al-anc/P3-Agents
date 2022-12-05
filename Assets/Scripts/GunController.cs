using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public float fireRate = 15f;
    public float maxAmmo = 8f;
    public float gunAmmo;
    public float reloadCooldown, maxReloadCooldown;

    public Camera fpsCam;
    private float nextTimeToFire = 0f;
    public GameObject shot;
    public Animator anim;
    public GameObject reload;

    public static event Action OnBulletFired;

    [SerializeField]private bool isReloading;

    void Start()
    {
        gunAmmo = maxAmmo;
    }
    
    void Update () {
        if ((Input.GetButtonDown("Fire1") || Input.GetAxisRaw("Fire1") > 0)&& Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
        if (isReloading)
        {
            ReloadGun();
        }
    }

    void Shoot ()
    {
        if (gunAmmo > 0 && !isReloading)
        {
            Instantiate(shot);
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
                    Debug.Log("EnemyHit");
                }
            }
            anim.SetTrigger("shoot");
            Invoke("resetanim", 0.5f);
            
        }
        else if (gunAmmo <= 0)
        {
            isReloading = true;
            Instantiate(reload);
            anim.SetTrigger("reload");
            Invoke("resetanim1", 0.5f);
        }
    }

    void ReloadGun()
    {
        
        reloadCooldown = Mathf.Clamp(reloadCooldown, 0, maxReloadCooldown);
        reloadCooldown -= Time.deltaTime;
        if (reloadCooldown <= 0)
        {
            gunAmmo = maxAmmo;
            OnBulletFired?.Invoke();
            reloadCooldown = maxReloadCooldown;
            isReloading = false;
            return;
        }
        
    }

    void resetanim()
    {
        anim.SetBool("shoot", false);
    }
    void resetanim1()
    {
        anim.SetBool("reload", false);
    }
    
}
