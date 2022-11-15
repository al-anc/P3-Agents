using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemies : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Player.transform.position, transform.position);
        if (dist <= 3)
            {
                foreach (GameObject enemy in Enemies)
                {
                enemy.GetComponent<EnemyAi>().Activate();
                }
            }
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }
}
