using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contributors: Dominic
public class RoombaBerserk : MonoBehaviour
{
    [SerializeField] private Roomba roomba;

    // Checks if player is within proximity of the Roomba
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            roomba.playerDetected = true;
        }
    }
}
