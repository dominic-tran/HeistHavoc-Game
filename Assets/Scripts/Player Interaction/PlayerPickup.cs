using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private float pickUpDistance;
    [SerializeField] private Transform objectGrabPointTransform;

    public bool isDetected;

    private ObjectGrabbable objectGrabbable;
    private PlayerMovement player;

    private void Start()
    {
        player = this.transform.parent.GetComponent<PlayerMovement>();
        isDetected = false;
    }

    private void Update()
    {
        if(isDetected)
        {
            isDetected = false;
            DropObject();
        }
        // Player presses "E" key to pick up item
        // Press "E" again to drop item
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null) // If not carrying an object, try to grab
            {
                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, pickUpDistance))
                {
                    // Checks if the object contains the tag "Grabbable" and has ObjectGrabbable component
                    // Calls Grab() function
                    if (raycastHit.transform.CompareTag("Grabbable") &&
                       raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        // Updates weight value on player
                        player.WeightValue = objectGrabbable.GetComponent<ValuablesHandler>().valuables.GetWeight();

                        objectGrabbable.Grab(objectGrabPointTransform);
                        GetComponentInParent<PlayerMovement>().AnimatorPlayer.SetBool("isHolding", true);
                    }
                }
            }
            else // If player is currently carrying an object, drop current object in hand
            {
                DropObject();
            }
        }
    }

    private void DropObject()
    {
        player.WeightValue = 0;
        objectGrabbable.Drop();
        GetComponentInParent<PlayerMovement>().AnimatorPlayer.SetBool("isHolding", false);
        objectGrabbable = null;
    }
}
