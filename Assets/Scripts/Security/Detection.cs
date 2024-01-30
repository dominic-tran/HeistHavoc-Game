using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public GameObject player;
    public Vector3 spawnPosition;

    string playerTag;
    Transform lens;

    private PlayerPickup playerDrop;
    
    /*private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //PlayerMovement playerMovementInstance = GetComponent<PlayerMovement>();
            //playerMovementInstance.PlayerSpeed = 0;`
            Invoke("Respawn", 2f);
        }
    }*/
    void Start()
    {
        lens = transform.parent.GetComponent<Transform>();
        playerTag = GameObject.FindGameObjectWithTag("Player").tag;
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == playerTag) 
        {
            Vector3 direction = collision.transform.position - lens.position;
            RaycastHit hit;

            if (Physics.Raycast(lens.transform.position, direction.normalized, out hit, 1000)) 
            {
                Debug.Log(hit.collider.name);

                if (hit.collider.gameObject.tag == playerTag)
                {
                    //PlayerMovement playerMovementInstance = GetComponent<PlayerMovement>();
                    //playerMovementInstance.PlayerSpeed = 0;
                    //playerDrop = collision.gameObject.GetComponent<PlayerPickup>();
                    //playerDrop.isDetected = true;
                    Invoke("Respawn", 2f);
                }
            }
        }
    }
    private void Respawn()
    {
        
        player.transform.position = spawnPosition;

    }
}
