using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaBerserk : MonoBehaviour
{
    [SerializeField] private Roomba roomba;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            roomba.playerDetected = true;
        }
    }
}
