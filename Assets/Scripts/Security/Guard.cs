using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Security
{
    [SerializeField] GameObject securityGuard;
    [SerializeField] private bool enableUp;
    [SerializeField] private bool enableDown;
    [SerializeField] private bool enableLeft;
    [SerializeField] private bool enableRight;
    [SerializeField] private float minStop;
    [SerializeField] private float maxStop;
    private List<Quaternion> angles = new List<Quaternion>();
    
    public override void Start()
    {
        base.Start();
        Quaternion turnUp = Quaternion.Euler(0, 45, 0);
        Quaternion turnDown = Quaternion.Euler(0, 225, 0);
        Quaternion turnLeft = Quaternion.Euler(0, 315, 0);
        Quaternion turnRight = Quaternion.Euler(0, 135, 0);
        if (enableUp)
        {
            angles.Add(turnUp);
        }
        if (enableDown)
        {
            angles.Add(turnDown);
        }
        if (enableLeft)
        {
            angles.Add(turnLeft);
        }
        if (enableRight)
        {
            angles.Add(turnRight);
        }
        if (!enableUp && !enableDown && !enableLeft && !enableRight)
        {
            angles.Add(turnUp);
        }
        StartCoroutine(RandomRotationCoroutine());
    }
    IEnumerator RandomRotationCoroutine()
    {
        while (true)
        {
            float timer = Random.Range(minStop, maxStop);
            yield return new WaitForSeconds(timer);

            Move();
        }
    }

    public override void Move()
    {
        {
            securityGuard.transform.rotation = angles[Random.Range(0, angles.Count - 1)];
        }
    }
}
