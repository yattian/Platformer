using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public Transform target;  // Player's Transform
    public float speed;  // Movement speed

    private Vector2 moveDirection;

    private float distanceTravelled = 0f;
    public float maxDistance = 50f;

    private void Start()
    {
        // Calculate the initial direction towards the player
        moveDirection = (target.position - transform.position).normalized;

        // Calculate the rotation angle
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;

        // Apply the rotation to the object
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Update()
    {
        // Calculate the distance the object moves this frame
        float moveThisFrame = speed * Time.deltaTime;

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
        transform.position += (Vector3)moveDirection * moveThisFrame;
    }

}
