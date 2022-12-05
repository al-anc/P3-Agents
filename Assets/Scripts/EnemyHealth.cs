using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f;
    public GameObject ded;
    public Animator anim;
    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die ()
    {
        anim.SetTrigger("die");
        Instantiate(ded);
        Destroy(gameObject, 3f);
    }
}
