using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 150f;

    private PlayerMovement pM;
    
    void Start()
    {
        if (this.GetComponent<PlayerMovement>() != false)
        {
            pM = this.GetComponent<PlayerMovement>();
        }
    }
    
    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        pM.Loss();
    }
}
