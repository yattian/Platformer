using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    public Spawner spawner;
    private bool hasSpawned = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasSpawned)
        {
            spawner.SpawnObject();
            hasSpawned = true; // set the flag to true so it won't spawn again
        }
    }
}


