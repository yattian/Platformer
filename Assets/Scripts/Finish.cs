using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public TimerScript levelTimer;

    private AudioSource finishSound;
    private bool levelCompleted = false;
    public string levelIdentifier;  // Set this in the inspector or dynamically based on the scene name

    public ItemCollector itemCollector;  // Reference to the ItemCollector script

    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !levelCompleted && itemCollector.Cherries >= 3)
        {
            finishSound.Play();
            levelCompleted = true;
            levelTimer.StopTimer();

            // Fetch the elapsed time for the level
            float elapsedTime = levelTimer.GetTimeElapsed();

            // Save the high score if it's better than the stored time
            SaveHighScore("Level1HighScore", elapsedTime);

            Invoke("CompleteLevel", 2f);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !levelCompleted && itemCollector.Cherries >= 3)
        {
            if (levelIdentifier == "TutFlag")
            {
                finishSound.Play();
                levelCompleted = true;
                Invoke("CompleteLevel", 2f);
            } 
            else
            {
                finishSound.Play();
                levelCompleted = true;
                levelTimer.StopTimer();

                // Save the high score for the current level
                float currentTime = levelTimer.GetTimeElapsed();
                string highScoreKey = levelIdentifier + "HighScore";
                // Debug.Log(highScoreKey);
                if (!PlayerPrefs.HasKey(highScoreKey) || PlayerPrefs.GetFloat(highScoreKey) > currentTime)
                {
                    PlayerPrefs.SetFloat(highScoreKey, currentTime);
                }

                Invoke("CompleteLevel", 2f);
            }
            
        }
    }


    private void CompleteLevel()
    {
        if (levelIdentifier == "TutFlag")
        {
            // Load the main menu scene
            SceneManager.LoadScene("Start Screen");
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // SceneManager.LoadScene("High Scores");
    }

}

