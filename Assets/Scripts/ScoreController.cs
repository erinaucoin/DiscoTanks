using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private int scoreMain = 0;
    public Text score;
    public HighscoreAsset highscoreAsset;

    public void updateScore()
    {
        scoreMain++;
        score.text = "SCORE: " + scoreMain.ToString();
    }

    public void SaveHighsScore(string name, int score)
    {
        
    }

    public int GetScore()
    {
        return scoreMain;
    }
}
