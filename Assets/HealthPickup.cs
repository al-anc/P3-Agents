using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private PlayerHealth modifier;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<PlayerHealth>() != false)
        {
            modifier = col.gameObject.GetComponent<PlayerHealth>();
            if (modifier.health < modifier.maxHealth)
            {
                modifier.Restore(2);
                Destroy(this.gameObject);
            }
        }
    }
    
}
