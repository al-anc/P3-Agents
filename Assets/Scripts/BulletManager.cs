using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GunController ammo;
    List<BulletSprite> bullets = new List<BulletSprite>();

    private void OnEnable()
    {
        GunController.OnBulletFired += DrawBullets;
    }

    private void OnDisable()
    {
        GunController.OnBulletFired += DrawBullets;
    }

    private void Start()
    {
        DrawBullets();
    }

    public void DrawBullets()
    {
        ClearBullets();
        int bulletsToMake = (int)(ammo.gunAmmo);
        for(int i = 0; i < bulletsToMake; i++)
        {
            CreateEmptyBullet();
        }

        for(int i = 0; i < bullets.Count; i++)
        {
            int bulletStatusRemainder = (int)Mathf.Clamp(ammo.gunAmmo- (i*1), 0, 1);
            bullets[i].SetBulletImage((BulletStatus)bulletStatusRemainder);
        }
    }

    public void CreateEmptyBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.SetParent(transform);

        BulletSprite bulletComponent = newBullet.GetComponent<BulletSprite>();
        bulletComponent.SetBulletImage(BulletStatus.Empty);
        bullets.Add(bulletComponent);
    }

    public void ClearBullets()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        bullets = new List<BulletSprite>();
    }
}
