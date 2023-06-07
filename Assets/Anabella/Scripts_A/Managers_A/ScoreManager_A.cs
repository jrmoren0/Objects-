using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager_A : MonoBehaviour
{
    private int score;
    private int highScore;

    // Start is called before the first frame update
    void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    //Changed as the method used to update the score is calling the method
    //from the UI Manager instead of using an event
    public void IncrementScore()
    {
        score++;
        GameManager_A.GetInstance().uiManager.UpdateScore();
        if (score > highScore)
        {
            highScore = score;
            GameManager_A.GetInstance().uiManager.UpdateHighScore();
            SetHighScore();
        }
    }

    public void SetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }
}
