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
    public float DetectionDist;
    public float attackDist;
    private float orriginalAttackDist;
    public LayerMask layerMask;
    // public LayerMask PlayerLayerMask;
    private Vector3 PlayerPos;
    public bool SeesPlayer;
    public bool canFollow;
    public float MinDist;

    public Transform target;
    private UnityEngine.AI.NavMeshAgent ai;
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<UnityEngine.AI.NavMeshAgent>();

        orriginalAttackDist = attackDist;

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
        float dist = Vector3.Distance(Player.transform.position, transform.position);
        PlayerPos.x = Player.transform.position.x;
        PlayerPos.z = Player.transform.position.z;
        PlayerPos.y = transform.position.y;
        //Debug.Log(dist);
        if (!spottedPlayer)
        {
            Patrol();
        }
        if (spottedPlayer == true)
        {
            transform.LookAt(PlayerPos);
        }
        if (spottedPlayer == false)
        {
            attackDist = orriginalAttackDist;
        }
        if (dist <= DetectionDist && dist > attackDist)
        {
            Activate();
        }
        if (dist < DetectionDist && dist <= attackDist && attack == false)
        {
            attack = true;
            ai.speed = 0;
            Invoke(nameof(shoot), 1f);
        }
        if (dist < MinDist)
        {
            ai.speed = 0;
        }
        // if (dist > orriginalAttackDist)
        // {
        //     spottedPlayer = false;
        // }
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (spottedPlayer == true)
        {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            // Debug.Log("Hit Wall");
            if (hit.transform.tag == "Player")
            {
                SeesPlayer = true;
            }
            else
            {
                SeesPlayer = false;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            // Debug.Log("Hit Player");
        }
        }

        if (canFollow == true)
        {
        if (spottedPlayer == true && SeesPlayer == false)
        {
            Invoke(nameof(Reposistion), 0f);
        }
        else if (spottedPlayer == true && SeesPlayer == true)
        {
            attackDist = attackDist;
        }
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
        ai.speed = Speed;
        spottedPlayer = true;
        target = Player.transform;
        UpdateDestination(target.position);
        // Invoke(nameof(ResetAttack), 1f);
    }

    public virtual void ResetAttack()
    {
        attack = false;
        if (dist > attackDist)
        {
            // target = Player.transform;
            // UpdateDestination(target.transform);
        }
    }
    public void shoot()
    {
        Rigidbody clone;
        clone = Instantiate(bullet, fireslot.transform.position, Player.transform.rotation);
        // GameObject.Instantiate(bullet, fireslot.transform.position, fireslot.transform.rotation);
        clone.velocity = (Player.transform.position - clone.position).normalized * projectileSpeed;
        Invoke(nameof(ResetAttack), 1f);
    }
    
    public void Reposistion()
    {
        attackDist = attackDist - 1;
        canFollow = false;
        Invoke(nameof(ResetFollow), 1f);
    }

    public void ResetFollow()
    {
        canFollow = true;
    }
}
