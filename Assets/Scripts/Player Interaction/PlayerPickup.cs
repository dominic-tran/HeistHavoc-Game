using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private float pickUpDistance;
    [SerializeField] private Transform objectGrabPointTransform;

    private ObjectGrabbable objectGrabbable;

    private void Update()
    {
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
                        objectGrabbable.Grab(objectGrabPointTransform);
                        GetComponentInParent<PlayerMovement>().AnimatorPlayer.SetBool("isHolding", true);
                    }
                }
            }
            else // If player is currently carrying an object, drop current object in hand
            {
                objectGrabbable.Drop();
                GetComponentInParent<PlayerMovement>().AnimatorPlayer.SetBool("isHolding", false);
                objectGrabbable = null;
            }
        }
    }
}
