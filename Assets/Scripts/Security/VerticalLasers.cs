using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalLasers : Security
{

    [SerializeField] private float moveDistance = 5f;  
    [SerializeField] private float moveSpeed = 1f;     
    [SerializeField] private bool upAndDown = true;

    private float initialX;          
    private float initialZ;

    public override void Start()
    {
        base.Start();
        initialX = transform.position.x;
        initialZ = transform.position.z;
    }

    void Update()
    {
        Move();
    }
     public override void Move()
     {
         float newX = initialX + Mathf.Sin(Time.time * moveSpeed) * moveDistance;
         float newZ = initialZ + Mathf.Sin(Time.time * moveSpeed) * moveDistance;

         if (upAndDown)
         {
             transform.position = new Vector3(newX, transform.position.y, newZ);
         }
         else
         {
             transform.position = new Vector3(-newX, transform.position.y, newZ);
         }
     }
}
