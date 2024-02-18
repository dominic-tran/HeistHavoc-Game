using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

// Contributors: Jacky, Nick
public class Roomba : Security
{
    [SerializeField] GameObject roomba;
    [SerializeField] private float degreesPerSecond = 20;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float backupDuration = 1.0f; // Duration to back up when hitting a wall
    private bool isBackingUp = false;
    private float backupTimer = 0.0f;
    private BoxCollider roombaCollider;

    public override void Start()
    {
        base.Start();
        roombaCollider = roomba.GetComponent<BoxCollider>();

    }
    void Update()
    {
        if (!isBackingUp)
        {
            Move();
        }
        else
        {
            // Back up for the specified duration
            backupTimer += Time.deltaTime;
            if (backupTimer >= backupDuration)
            {
                backupTimer = 0.0f;
                isBackingUp = false;
            }
        }
    }

    public override void Move()
    {
        if (!isBackingUp)
        {
            // Rotate around the Y-axis (upward)
            roomba.transform.Rotate(Vector3.up * degreesPerSecond * Time.deltaTime);
            // Move along the Roomba's local Y-axis (forward)
            roomba.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }

    // OnCollisionEnter is called when the Roomba collides with another collider
    private void OnCollisionEnter(Collision other)
    {
        // Check if the collision tag is "Collide"
        if (other.gameObject.CompareTag("Collide"))
        {
            // If it hits a wall, set isBackingUp to true
            isBackingUp = true;
            //Currently not triggering
            Debug.Log("backing up");
            // Rotate the Roomba 180 degrees (you can adjust this if needed)
            roomba.transform.Rotate(Vector3.up, 180.0f);

            // Reset the backup timer
            backupTimer = 0.0f;
        }
    }
}
