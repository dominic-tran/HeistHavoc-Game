using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


// Contributors: Dominic, Nick
public class ObjectGrabbable : NetworkBehaviour
{
    [SerializeField] private GameObject valuableObj;
    private Rigidbody rb;
    private Transform objectGrabPointTransform;
    private Collider objectCollider;
    private FollowTransform followTransform;
    private IValuables valuableParent;
    
    private void Start()
    {
        followTransform = GetComponent<FollowTransform>();
        rb = GetComponent<Rigidbody>();
        objectCollider = valuableObj.GetComponent<Collider>();
    }

    public GameObject GetSOValuablesDefinition()
    {
        return valuableObj;
    }

    public void SetValuableParent(IValuables valuableParent)
    {
        SetValuableParentServerRpc(valuableParent.GetNetworkObject());
    }

    [ServerRpc(RequireOwnership = false)]
    private void SetValuableParentServerRpc(NetworkObjectReference valuableParentNetworkObjectReference)
    {
        SetValuableParentClientRpc(valuableParentNetworkObjectReference);
    }

    [ClientRpc]
    private void SetValuableParentClientRpc(NetworkObjectReference valuableParentNetworkObjectReference)
    {
        valuableParentNetworkObjectReference.TryGet(out NetworkObject valuableParentNetworkObject);
        IValuables valuableParent = valuableParentNetworkObject.GetComponent<IValuables>();

        if (this.valuableParent != null)
        {
            this.valuableParent = null;
        }

        this.valuableParent = valuableParent;

        if (valuableParent.HasValuable())
        {
            Debug.LogError("IValuables already has a valuableObject!");
        }

        valuableParent.SetValuableObject(this);

        //followTransform.SetTargetTransform(valuableParent.Get)

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
            transform.position = objectGrabPointTransform.position;
            transform.forward = objectGrabPointTransform.forward;
        }
    }
}
