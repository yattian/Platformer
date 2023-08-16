using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform playerTransform;

    public void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);

        // Check the tag of this spawner and add the appropriate movement script to the spawned object.
        if (this.CompareTag("MovingUp"))
        {
            spawnedObject.AddComponent<MovingUpwards>();
        }
        else if (this.CompareTag("MovingLeft"))
        {
            spawnedObject.AddComponent<MovingLeft>();
        }
        else if (this.CompareTag("MovingDown"))
        {
            spawnedObject.AddComponent<MovingDownwards>();
        }
        else if (this.CompareTag("MovingPlayer"))
        {
            MoveTowardsPlayer moveTowardsPlayer = spawnedObject.AddComponent<MoveTowardsPlayer>();
            moveTowardsPlayer.target = playerTransform;
            moveTowardsPlayer.speed = 10f;
        }
    }
}

