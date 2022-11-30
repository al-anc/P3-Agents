using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSprite : MonoBehaviour
{
    public Sprite bullet, emptyBullet;

    Image bulletImg;

    private void Awake()
    {
        bulletImg = GetComponent<Image>();
    }

    public void SetBulletImage(BulletStatus status)
    {
        switch (status)
        {
            case BulletStatus.Empty:
                bulletImg.sprite = emptyBullet;
                break;
            case BulletStatus.Full:
                bulletImg.sprite = bullet;
                break;
        }
    }
}

public enum BulletStatus
{
    Empty = 0,
    Full = 1
}
