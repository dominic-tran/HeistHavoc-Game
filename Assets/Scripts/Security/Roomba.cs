using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

// Contributors: Nick, Jacky
public class Roomba : Security
{
    [SerializeField] GameObject roomba;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float berserkTime;
    [SerializeField] private Transform ground;
    [HideInInspector] public bool playerDetected;

    private bool hitObject;
    private bool rotateNegative;

    private float rotateDegrees;
    private float totalDegreesTurned;
    private float originalMoveSpeed;
    private float time;

    // Constant float values for Roomba rotation values
    private const float MIN_ROTATE_DEGREES = 90f;
    private const float MAX_ROTATE_DEGREES = 180f;
    private const float DEGREES_PER_SEC = 20f;
    private const float BERSERK_MULT = 3f;

    public override void Start()
    {
        base.Start();
        // Ignores collision with the floor
        Physics.IgnoreCollision(ground.GetComponent<Collider>(), this.GetComponent<Collider>());
        hitObject = false;
        playerDetected = false;
        rotateNegative = true;
        totalDegreesTurned = 0f;
        originalMoveSpeed = moveSpeed;
        time = 0f;
    }

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (playerDetected && time < berserkTime)
        {
            // STATE 3: Berserk mode when it detects a player nearby
            moveSpeed = originalMoveSpeed * BERSERK_MULT;
            roomba.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;

            time += Time.deltaTime;
        }
        else
        {
            // If no player detected
            time = 0f;
            moveSpeed = originalMoveSpeed;
            roomba.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.black;
            playerDetected = false;
        }

        if (!hitObject)
        {
            // STATE 1: Default move forward
            ForwardMovement();
        }
        else if (totalDegreesTurned <= rotateDegrees)
        {
            // STATE 2: Rotate random amount to move again
            if (rotateNegative)
            {
                RotateLeft();
            }
            else
            {
                RotateRight();
            }

            TotalTime();
        }
        else
        {
            // Resets values after Roomba completes rotation
            totalDegreesTurned = 0f;
            rotateNegative = true;
            hitObject = false;
        }
    }

    // Handles Roomba moving forward
    private void ForwardMovement()
    {
        roomba.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    // Handles Roomba rotating left
    private void RotateLeft()
    {
        if(playerDetected)
        {
            roomba.transform.Rotate(new Vector3(0, 0, -(DEGREES_PER_SEC * BERSERK_MULT) * Time.deltaTime));
        }
        else
        {
            roomba.transform.Rotate(new Vector3(0, 0, -DEGREES_PER_SEC) * Time.deltaTime);
        }
    }

    // Handles Roomba rotating right
    private void RotateRight()
    {
        if (playerDetected)
        {
            roomba.transform.Rotate(new Vector3(0, 0, (DEGREES_PER_SEC * BERSERK_MULT) * Time.deltaTime));
        }
        else
        {
            roomba.transform.Rotate(new Vector3(0, 0, DEGREES_PER_SEC) * Time.deltaTime);
        }
    }

    // Calculates the total time elapsed while Roomba is rotating
    private void TotalTime()
    {
        if (playerDetected)
        {
            totalDegreesTurned += DEGREES_PER_SEC * BERSERK_MULT * Time.deltaTime;
        }
        else
        {
            totalDegreesTurned += DEGREES_PER_SEC * Time.deltaTime;
        }
    }

    // Checks if Roomba collides with any object in front of it
    private void OnCollisionEnter(Collision collision)
    {
        rotateDegrees = Random.Range(MIN_ROTATE_DEGREES, MAX_ROTATE_DEGREES);
        if(Random.Range(0, 2) == 0)
        {
            rotateNegative = false;
        }
        hitObject = true;
    }
}