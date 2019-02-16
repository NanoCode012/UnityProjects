using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private Ball ball;
    private PinSetter pinSetter;
    private ScoreDisplay scoreDisplay;

    private readonly List<int> pinsFallen = new List<int>();

    // Use this for initialization
    void Start ()
    {
        ball = FindObjectOfType<Ball>();
        pinSetter = FindObjectOfType<PinSetter>();
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl(int numberOfPinsFallen)
    {
        try
        {
		    ball.Reset();

		    pinsFallen.Add(numberOfPinsFallen);

		    pinSetter.DoAction(ActionMaster.NextAction(pinsFallen));

        }
        catch
        {
            Debug.LogWarning("Something went wrong in Bowl");
        }

        try
        {
            scoreDisplay.FillRolls(pinsFallen);
            scoreDisplay.FillFrames(ScoreMaster.GetScoreCumulative(pinsFallen));
        }
        catch
        {
            Debug.LogWarning("Something went wrong with FillRollCard");
        }
    }

    
}
