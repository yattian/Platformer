using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public Transform target;  // Player's Transform
    public float speed;  // Movement speed

    private Vector2 moveDirection;

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
        // Move the object continuously in the initial direction
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
    }
}
