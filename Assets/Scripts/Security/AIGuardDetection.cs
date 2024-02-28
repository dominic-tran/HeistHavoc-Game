using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contributors: Dominic
public class AIGuardDetection : MonoBehaviour
{
    private AIGuard guard;

    private void Start()
    {
        guard = GetComponentInParent<AIGuard>();
    }

    // Checks if guard collides with player
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            guard.playerInRange = true;
            guard.followPlayer = other.GetComponent<Transform>();
        }
    }
}
