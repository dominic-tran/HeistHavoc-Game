using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

// Contributors: Dominic
public abstract class Security : NetworkBehaviour
{
    private GameObject player;
    private const float CAUGHT_TIME = 2f;

    public virtual void Start()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            collision.enabled = false;
            collision.GetComponent<PlayerMovement>().isFrozen = true;
            Invoke("Respawn", CAUGHT_TIME);
        }
    }

    void Respawn()
    {
        Transform spawnLoc = GameObject.Find("playerSpawnLocation").transform;

        player.GetComponent<Collider>().enabled = true;
        player.GetComponent<PlayerMovement>().isFrozen = false;
        player.transform.position = spawnLoc.position;
    }

    public abstract void Move();
}
