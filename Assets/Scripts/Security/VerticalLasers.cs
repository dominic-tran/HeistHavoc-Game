using UnityEngine;

public class VerticalLasers : Security
{

    [SerializeField] private float moveDistance = 5f;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private bool upAndDown = true;

    private float initialX;
    private float initialZ;

    private float newX;
    private float newZ;

    public override void Start()
    {
        base.Start();
        initialX = transform.localPosition.x;
        initialZ = transform.localPosition.z;

        Debug.Log(initialX + " " + initialZ);
    }

    void Update()
    {
        Move();
    }
    public override void Move()
    {
        newX = initialX + Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        if (upAndDown)
        {
            newZ = initialZ + Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        }
        else
        {
            newZ = initialZ - Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        }

        transform.position = new Vector3(newX, transform.position.y, newZ);
    }
}