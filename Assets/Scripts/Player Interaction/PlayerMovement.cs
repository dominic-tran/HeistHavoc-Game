using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed; // Set player speed
    [SerializeField] private float rotationSpeed; // Set player rotation/turn speed
    [SerializeField] private Animator animatorPlayer;

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

        if(moveDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        } // Player takes some time to turn instead of turning instantly on input

        animatorPlayer.SetFloat("Speed", Mathf.Abs(x) + Mathf.Abs(y));
    }

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
