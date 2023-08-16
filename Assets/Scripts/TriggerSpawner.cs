using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    public Spawner spawner;
    private bool hasSpawned = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.CompareTag("Delay1") && collision.gameObject.CompareTag("Player") && !hasSpawned)
        {
            Invoke("SpawnTrap", 2);
            hasSpawned = true; // set the flag to true so it won't spawn again
        }
        else if (collision.gameObject.CompareTag("Player") && !hasSpawned)
        {
            spawner.SpawnObject();
            hasSpawned = true; // set the flag to true so it won't spawn again
        }
    }

    private void SpawnTrap()
    {
        spawner.SpawnObject();
    }
}


