using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    public void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);

        // Check if this spawner has the "MovingTrap" tag.
        if (this.CompareTag("MovingUp"))
        {
            spawnedObject.AddComponent<MovingUpwards>();
        }
        if (this.CompareTag("MovingLeft"))
        {
            spawnedObject.AddComponent<MovingLeft>();
        }
    }
}
