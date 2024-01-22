using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed; // Set player speed
    [SerializeField] private float rotationSpeed; // Set player rotation/turn speed
    [SerializeField] private Animator animatorPlayer;
    [SerializeField] private LayerMask terrainLayer;

    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(x, 0, y);
        moveDir.Normalize(); // Normalize vector so diagonal movement is not faster than linear movement
        rb.velocity = moveDir * playerSpeed;

        // Player takes some time to turn instead of turning instantly on input
        if (moveDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        keepGrounded();
        animatorPlayer.SetFloat("Speed", Mathf.Abs(x) + Mathf.Abs(y));
    }

    // Keeps player on the floor at all times
    // - Shoots a ray cast downward
    // - If the line hits the ground, move the player at a set height above the ground
    private void keepGrounded()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if(Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity))
        {
            if(hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y;
                transform.position = movePos;
            }
        }
    }

    // Getter-Setter method for the player animator
    public Animator AnimatorPlayer
    {
        get
        {
            return this.animatorPlayer;
        }
        set
        {
            animatorPlayer = value;
        }
    }
}
