using UnityEngine;

public class MovingUpwards : MonoBehaviour
{
    private float moveSpeed = 25.0f; // Speed at which the object moves upwards.

    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
