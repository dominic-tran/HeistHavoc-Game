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
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null) // If not carrying an object, try to grab
            {
                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, pickUpDistance))
                {
                    if (raycastHit.transform.CompareTag("Grabbable") &&
                       raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        GetComponent<PlayerMovement>().AnimatorPlayer.SetBool("isHolding", true);
                    }
                }
            }
            else
            {
                objectGrabbable.Drop();
                GetComponent<PlayerMovement>().AnimatorPlayer.SetBool("isHolding", false);
                objectGrabbable = null;
            }
        }
    }
}
