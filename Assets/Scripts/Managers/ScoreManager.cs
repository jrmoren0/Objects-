using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{

    private int score;

    private int highscore;


    //Using Actions
    //public Action onScoreUpdate;

    public UnityEvent OnscoreUpdated;
    public UnityEvent OnHighScoreUpdated;


    // Start is called before the first frame update
    void Awake()
    {
       
        highscore = PlayerPrefs.GetInt("HighScore");
    }


    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highscore;
    }




    public void IncrementScore()
    {
        score++;

        //Invokeing Actions
        // onScoreUpdate?.Invoke();

        OnscoreUpdated?.Invoke();

       if(score > highscore)
        {
            highscore = score;
            OnHighScoreUpdated?.Invoke();

            SetHighScore();
         
        }



    }


    public void SetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highscore);
    }


}
