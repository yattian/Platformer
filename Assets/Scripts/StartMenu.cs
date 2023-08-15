using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void HighScore()
    {
        SceneManager.LoadScene("High Scores");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
