using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private Ball ball;
    private PinSetter pinSetter;

    private readonly List<int> pinsFallen = new List<int>();

    // Use this for initialization
    void Start ()
    {
        ball = FindObjectOfType<Ball>();
        pinSetter = FindObjectOfType<PinSetter>();
    }

    public void Bowl(int numberOfPinsFallen)
    {
        pinsFallen.Add(numberOfPinsFallen);

        var action = ActionMaster.NextAction(pinsFallen);

        pinSetter.DoAction(action);
        ball.Reset();
    }

    
}
