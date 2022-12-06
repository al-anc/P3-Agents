using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 10f;
    public float maxHealth;
    [SerializeField] public GameObject Health100, Health75, Health50, Health25;

    private PlayerMovement pM;
    
    void Start()
    {
        if (this.GetComponent<PlayerMovement>() != false)
        {
            pM = this.GetComponent<PlayerMovement>();
        }
    }
    void Update()
    {
        int totalHealth = (int)((double)health / maxHealth * 100);
        if (totalHealth <= 100 && totalHealth > 75)
        {
            Health100.SetActive(true);
            Health50.SetActive(false);
            Health25.SetActive(false);
            Health75.SetActive(false);
        }
        if (totalHealth <= 75 && totalHealth > 50)
        {
            Health100.SetActive(false);
            Health50.SetActive(false);
            Health25.SetActive(false);
            Health75.SetActive(true);
        }
        if (totalHealth <= 50 && totalHealth > 25)
        {
            Health100.SetActive(false);
            Health75.SetActive(false);
            Health25.SetActive(false);
            Health50.SetActive(true);
        }
        if (totalHealth <= 25 && totalHealth > 0)
        {
            Health100.SetActive(false);
            Health75.SetActive(false);
            Health50.SetActive(false);
            Health25.SetActive(true);
        }
    }
    
    public virtual void TakeDamage (float amount)
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
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            TakeDamage(1);
        }
    }

    public void Restore(float amount)
    {
        health = Mathf.Clamp(health, -0.00001f, maxHealth);
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
