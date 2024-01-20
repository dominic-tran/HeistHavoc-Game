using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator animator;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(x, 0, y);
        moveDir.Normalize();
        rb.velocity = moveDir * playerSpeed;

        if(moveDir != Vector3.zero)
        {
            // transform.forward = moveDir; // Turns player instantly to direction
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        animator.SetFloat("Speed", Mathf.Abs(x) + Mathf.Abs(y));
    }
}
