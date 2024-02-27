using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Roomba : Security
{
    [SerializeField] GameObject roomba;
    [SerializeField] private float degreesPerSecond = 20;
    [SerializeField] private float moveSpeed = 2;

    public override void Start()
    {
        base.Start();
    }
    void Update()
    {
        Move();
    }
    public override void Move()
    {
        //roomba.transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime); //rotates roomba
        roomba.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        //if ()
    }
}