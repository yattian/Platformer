using UnityEngine;

public class KillPlayerOnTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerLife playerLife = other.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.Die();
            }
        }
    }

}
