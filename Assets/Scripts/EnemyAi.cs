using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public List<Transform> PatrolPoints = new List<Transform>();
    private int currentWaypoint = 0;
    public int waypointFollowing = 0;
    public float waypointDistance = 3f;
    public float Speed = 3f;
    public int patrolNum;
    public bool spottedPlayer;
    public GameObject Player;
    private float dist;
    public Rigidbody bullet;
    public GameObject fireslot;
    private bool attack;
    public float projectileSpeed;

    public Transform target;
    private UnityEngine.AI.NavMeshAgent ai;
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if(target == null)
        {
            target = PatrolPoints[0].transform;
            UpdateDestination(target.position);
        }
    }
    //updates where the player goes to save code
    public virtual void UpdateDestination(Vector3 newDestination)
    {
        ai.destination = newDestination;
    }
    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(Player.transform.position, transform.position);
        Debug.Log(dist);
        if (!spottedPlayer)
        {
            Patrol();
        }
    }
        private bool atDestination;
        public virtual void Patrol()
    {
        if (GetComponent<UnityEngine.AI.NavMeshAgent>().remainingDistance < 0.5f && atDestination == false)
        {
            atDestination = true;
            //if the player isnt at the last point
            if (patrolNum < PatrolPoints.Count - 1)
            {
                patrolNum++;
            }
            //if the player is at the last point go to the first one
            else
            {
                patrolNum = 0;

            }
            target = PatrolPoints[patrolNum];
            UpdateDestination(target.position);
        }
        else
        {
            atDestination = false;
        }
    }
    public void Activate()
    {
        spottedPlayer = true;
        target = Player.transform;
        UpdateDestination(target.position);
        if (dist <= 5 && attack == false)
        {
            attack = true;
            ai.speed = 0;
            Invoke(nameof(shoot), 1f);
        }
        // Invoke(nameof(ResetAttack), 1f);
    }

    public virtual void ResetAttack()
    {
        attack = false;
    }
    public void shoot()
    {
        Rigidbody clone;
        clone = Instantiate(bullet, fireslot.transform.position, Player.transform.rotation);
        // GameObject.Instantiate(bullet, fireslot.transform.position, fireslot.transform.rotation);
        clone.velocity = (Player.transform.position - clone.position).normalized * projectileSpeed;
        Invoke(nameof(ResetAttack), 1f);
    }
}
