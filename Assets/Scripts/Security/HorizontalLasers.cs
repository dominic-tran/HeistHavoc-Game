using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Security Camera will use inheritance
public class HorizontalLasers : Security
{
    // Start is called before the first frame update
    public float moveDistance = 5f;   // Set the distance the object moves up and down
    public float moveSpeed = 1f;      // Set the speed of the movement

    private float initialY;           // Store the initial Y position for reference

    public override void Start()
    {
        base.Start();
        initialY = transform.position.y;
    }

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        float newY = initialY + Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
