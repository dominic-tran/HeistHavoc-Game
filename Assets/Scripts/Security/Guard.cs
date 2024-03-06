using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// Contributors: Nick
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
    private int randomN;
    private Quaternion temp;

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
        randomN = Random.Range(0, angles.Count);
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
            securityGuard.transform.rotation = angles[randomN];
            temp = angles[randomN];
            angles.RemoveAt(randomN);
            randomN = Random.Range(0, angles.Count);
            angles.Add(temp);
        }
    }
}
