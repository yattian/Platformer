using UnityEngine;

public class MovingLeft : MonoBehaviour
{
    private float moveSpeed = 25.0f; // Speed at which the object moves upwards.

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
