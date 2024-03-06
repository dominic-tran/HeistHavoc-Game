using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

// Contributors: Dominic, Nick
public class PlayerMovement : NetworkBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float playerSpeed; // Set player speed
    [SerializeField] private float playerSprint; // Set player speed
    [SerializeField] private float rotationSpeed; // Set player rotation/turn speed

    [Header("Player Input")]
    [SerializeField] private string inputHorizontal;
    [SerializeField] private string inputVertical;
    [SerializeField] private string inputSprint;

    [Header("Misc.")]
    [SerializeField] private Color playerColor;
    [SerializeField] private Animator animatorPlayer;

    private Rigidbody rb;
    private Renderer bodyColor;
    private float initialSpeed;
    private float weightValue;

    private const int ANIM_DOUBLE_SPEED = 2;
    private const int ANIM_NORMAL_SPEED = 1;

    [HideInInspector] public bool isFrozen;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        initialSpeed = playerSpeed;
        weightValue = 0;
        isFrozen = false;

        // Change color of player
        bodyColor = gameObject.transform.GetChild(0).GetComponent<Renderer>();
        bodyColor.material.color = playerColor;
    }

    private void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        if(!isFrozen)
        {
            float x = Input.GetAxis(inputHorizontal);
            float y = Input.GetAxis(inputVertical);

            Vector3 moveDir = new Vector3(x, 0, y);
            moveDir.Normalize(); // Normalize vector so diagonal movement is not faster than linear movement
            rb.velocity = moveDir * playerSpeed;

            // Sprint mechanic
            if (Input.GetKey(inputSprint))
            {
                playerSpeed = playerSprint - weightValue;
                animatorPlayer.speed = ANIM_DOUBLE_SPEED;
            }
            else
            {
                playerSpeed = initialSpeed - weightValue;
                animatorPlayer.speed = ANIM_NORMAL_SPEED;
            }

            // Player takes some time to turn instead of turning instantly on input
            if (moveDir != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }

            animatorPlayer.SetFloat("Speed", Mathf.Abs(x) + Mathf.Abs(y));
            KeepGrounded();
        }
        else
        {
            animatorPlayer.SetFloat("Speed", 0);
            rb.velocity = Vector3.zero;
        }
    }

    // Keeps player on the floor at all times
    // - Shoots a ray cast downward
    // - If the line hits the ground, move the player at a set height above the ground
    private void KeepGrounded()
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

    public float WeightValue
    {
        get
        {
            return this.weightValue;
        }
        set
        {
            weightValue = value;
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
