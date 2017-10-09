using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public static int score;
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        Reset();
    }

    public void Score(int points = 1){
        score += points;
        scoreText.text = score.ToString();
    }

    public static void Reset(){
        score = 0;
    }
}
