using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    [SerializeField] private GameObject barObj;

    private Rigidbody rb;
    private Transform objectGrabPointTransform;
    private Collider objectCollider;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        objectCollider = barObj.GetComponent<Collider>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectCollider.isTrigger = true;
        rb.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectCollider.isTrigger = false;
        rb.useGravity = true;
    }

    private void FixedUpdate()
    {
        if(objectGrabPointTransform != null)
        {
            rb.MovePosition(objectGrabPointTransform.position);
            rb.transform.forward = objectGrabPointTransform.forward;
        }
    }
}
