using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffZone : MonoBehaviour
{
    private ScoringSystem scoringSystem;
    private SOValuablesDefinition valuable;

    private void Start()
    {
        scoringSystem = GameObject.Find("ScoringSystem").GetComponent<ScoringSystem>();
    }

    // Check if the object was a grabbable object
    // Destroy object if it is placed in the drop-off zone
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Grabbable"))
        {
            // Obtain the collider's Scriptable Object values through a handler
            valuable = other.transform.parent.gameObject.GetComponent<ValuablesHandler>().valuables;
            scoringSystem.AddToScore(valuable.GetValue());
            Destroy(other.gameObject);
        }
    }
}
