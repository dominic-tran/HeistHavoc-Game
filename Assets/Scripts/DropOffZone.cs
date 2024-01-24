using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffZone : MonoBehaviour
{
    // Add code that will work with a Score Manager script in the future

    // Check if the object was a grabbable object
    // Destroy object if it is placed in the drop-off zone
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Grabbable"))
        {
            Destroy(other.gameObject);
        }
    }
}
