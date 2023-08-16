using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int Cherries { get; private set; } = 0;  // This allows external read but only internal modification

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            Cherries++;
            cherriesText.text = "Cherries: " + Cherries;
        }
        if (collision.gameObject.CompareTag("DisappearTrap"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
        }
   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DisappearWall"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
        }
    }

}
