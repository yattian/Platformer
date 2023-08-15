using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBlow : MonoBehaviour
{
    public float blowStrength = 5f; // The strength of the fan's blow

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb)
            {
                rb.AddForce(Vector2.up * blowStrength * 10, ForceMode2D.Force);

            }
        }
    }

    private float originalGravityScale;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb)
            {
                originalGravityScale = rb.gravityScale;
                rb.gravityScale = 0.5f;  // or some other reduced value
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb)
            {
                rb.gravityScale = originalGravityScale;
            }
        }
    }

}
