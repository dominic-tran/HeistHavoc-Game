using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIGuard : Security
{
    [SerializeField] private Transform followPlayer;

    private Animator animatorPlayer;
    private NavMeshAgent agent;

    private float x;
    private float y;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Move();
        agent = GetComponent<NavMeshAgent>();
        animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = followPlayer.position;
        
        KeepGrounded();
    }

    public override void Move()
    {
        StartCoroutine(IsMoving());
    }

    IEnumerator IsMoving()
    {
        Vector3 prevPos = transform.position;
        yield return new WaitForSeconds(Time.deltaTime);
        Vector3 currPos = transform.position;

        if( prevPos == currPos )
        {
            animatorPlayer.SetBool("Moving", true);
        }
        else
        {
            animatorPlayer.SetBool("Moving", false);
        }
    }
    private void KeepGrounded()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y;
                transform.position = movePos;
            }
        }
    }
}