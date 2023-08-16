using UnityEngine;

public class MovingLeft : MonoBehaviour
{
    public float moveSpeed = 25.0f; // Speed at which the object moves left.
    private float distanceTravelled = 0f; // Distance the object has traveled.
    public float maxDistance = 100f; // Maximum distance the object can travel before it is destroyed.

    void Update()
    {
        // Calculate the distance the object moves this frame
        float moveThisFrame = moveSpeed * Time.deltaTime;

        // Increment the total distance traveled
        distanceTravelled += moveThisFrame;

        // Check if the object has traveled its maximum allowed distance
        if (distanceTravelled >= maxDistance)
        {
            // If so, destroy the object and exit the method early
            Destroy(gameObject);
            return;
        }

        // Otherwise, move the object as usual
        transform.position += Vector3.left * moveThisFrame;
    }
}
