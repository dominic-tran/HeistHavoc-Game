using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Security : MonoBehaviour
{
    private GameObject player;
    private const float CAUGHT_TIME = 2f;

    public virtual void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.enabled = false;
            player.GetComponent<PlayerMovement>().isFrozen = true;
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
