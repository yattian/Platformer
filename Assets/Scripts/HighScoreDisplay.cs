using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*public class HighScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();
        DisplayHighScore("Level1HighScore");
    }

    private void DisplayHighScore(string key)
    {
        // Get the saved high score, defaulting to 9999 if there's no saved value.
        float savedTime = PlayerPrefs.GetFloat(key, 9999);

        // Convert the time (in seconds) to a minutes:seconds format.
        string minutes = ((int)savedTime / 60).ToString("00");
        string seconds = (savedTime % 60).ToString("00");
        string milliseconds = ((int)(savedTime * 100) % 100).ToString("00");

        // Set the text component to show the high score.
        highScoreText.text = "Level 1 Best Time: " + minutes + ":" + seconds + "." + milliseconds;
    }
}*/
public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highScoreTextLevel1;
    public TextMeshProUGUI highScoreTextLevel2;
    public TextMeshProUGUI highScoreTextLevel3;

    private void Start()
    {
        DisplayHighScore("1HighScore", highScoreTextLevel1);
        DisplayHighScore("2HighScore", highScoreTextLevel2);
        DisplayHighScore("3HighScore", highScoreTextLevel3);
    }

    public void DisplayHighScore(string key, TextMeshProUGUI displayText)
    {
        if (displayText == null)
        {
            Debug.LogError("Text component not assigned for " + key);
            return;
        }

        float highScore = PlayerPrefs.GetFloat(key, 0);
        string minutes = ((int)highScore / 60).ToString("00");
        string seconds = (highScore % 60).ToString("00");
        string milliseconds = ((int)(highScore * 100) % 100).ToString("00");

        displayText.text = minutes + ":" + seconds + "." + milliseconds;
    }
}

