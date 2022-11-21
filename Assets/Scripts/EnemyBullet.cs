using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody rb;
    public float shootSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // GetComponent<ConstantForce>().relativeForce = new Vector3(0,0,100); 
        Destroy(this, 1f);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1f);
        Destroy(gameObject, 0.5f);
        }
        else { Destroy(gameObject); }
    }
}
