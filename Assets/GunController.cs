using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public float fireRate = 15f;

    public Camera fpsCam;

    private float nextTimeToFire = 0f;

    void Update () {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void Shoot ()
    {
        RaycastHit hit;
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
