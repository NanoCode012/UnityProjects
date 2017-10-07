using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    int score;
    Text myTextComponent;

    void Start()
    {
        myTextComponent = GetComponent<Text>();
        Reset();
    }

    public void Score(int points = 1){
        score += points;
        myTextComponent.text = "Score : " + score;
    }

    void Reset(){
        score = 0;
        myTextComponent.text = "Score : " + score;
    }
}
