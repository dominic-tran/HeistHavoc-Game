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

    // Grab() function that moves current object with the player's hands
    // Sets gravity to false to prevent jittering
    // Sets trigger to true to prevent collision while moving
    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectCollider.isTrigger = true;
        rb.useGravity = false;
    }

    // Drop() function that moves current object with the player's hands
    // Sets gravity to true to allow object to fall down
    // Sets trigger to false to allow collision when it falls and lands
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
