using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attach this to invisible trigger zones for checkpoints
public class Checkpoint : MonoBehaviour
{
    private RespawnPlayer playerRespawn;
    private void Awake()
    {
        playerRespawn = GameObject.FindGameObjectWithTag("Player").GetComponent<RespawnPlayer>();
    }

    // set checkpoint when collides with player
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collided with player");
            playerRespawn.SetCheckpoint(other.transform.position);
        }
            
    }
}
