using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public GameObject player;
    public Vector3 spawnPosition;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //PlayerMovement playerMovementInstance = GetComponent<PlayerMovement>();
            //playerMovementInstance.PlayerSpeed = 0;
            Invoke("Respawn", 2f);
        }
    }
    private void Respawn()
    {
        
        player.transform.position = spawnPosition;

    }
}
