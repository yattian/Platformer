using UnityEngine;

public class MovingDownwards : MonoBehaviour
{
    private float moveSpeed = 25.0f; // Speed at which the object moves upwards.

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }
}
