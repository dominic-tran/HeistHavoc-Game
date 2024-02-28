using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Contributors: Dominic, Adrian
public class AIGuard : Security
{
    [HideInInspector] public Transform followPlayer;
    [HideInInspector] public bool playerInRange;

    private Animator animatorPlayer;
    private NavMeshAgent agent;
    private float timeElapsed;

    // Patrol variables
    [Header("Patrol Variables")]
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float walkingRange;
    [SerializeField] private float fatigueTime;
    private Vector3 destPoint;
    private bool walkpointSet;
    private bool willWalk;

    private const float MAX_CHASE_TIME = 10f;
    private const float MAX_WALK_DISTANCE = 5f;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Move();
        agent = GetComponent<NavMeshAgent>();
        animatorPlayer = GetComponent<Animator>();
        willWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        // STATE 1: Follows player if the player is in range of the guard
        if (playerInRange)
        {
            agent.destination = followPlayer.position;
            timeElapsed += Time.deltaTime;

            willWalk = false;
            // STATE 2: Chase ends after 10 seconds if not caught
            if (timeElapsed >= MAX_CHASE_TIME)
            {
                timeElapsed = 0;
                playerInRange = false;
                agent.isStopped = true;
                // STATE 3: Guard is idle/walking around
                Invoke("WillWalk", fatigueTime);
            }
        }

        if(willWalk)
        {
            Walking();
        }

        KeepGrounded();
    }

    // Resets walking state
    private void WillWalk()
    {
        willWalk = true;
        agent.isStopped = false;
    }

    // Responsible for object walking towards random direction within NavMesh
    private void Walking()
    {
        if(walkpointSet)
        {
            agent.SetDestination(destPoint);
        }
        else
        {
            SearchForDest();
        }

        if(Vector3.Distance(transform.position, destPoint) < MAX_WALK_DISTANCE)
        {
            walkpointSet = false;
        }
    }

    // Handles calculation for random direction to rwalk to
    private void SearchForDest()
    {
        float z = Random.Range(-walkingRange, walkingRange);
        float x = Random.Range(-walkingRange, walkingRange);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(destPoint, Vector3.down, groundMask))
        {
            walkpointSet = true;
        }
    }

    public override void Move()
    {
        StartCoroutine(IsMoving());
    }

    // Responsible for handling moving animation of the security guard
    IEnumerator IsMoving()
    {
        while (true)
        {
            Vector3 prevPos = transform.position;
            yield return new WaitForSeconds(Time.deltaTime);
            Vector3 currPos = transform.position;

            if (prevPos == currPos)
            {
                animatorPlayer.SetBool("Moving", false);
            }
            else
            {
                animatorPlayer.SetBool("Moving", true);
            }
        }
    }

    // Keeps AI object grounded
    private void KeepGrounded()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform. position;
                movePos.y = hit.point.y;
                transform.position = movePos;
            }
        }
    }
}