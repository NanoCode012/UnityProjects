using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    public static bool GameEnd { get; set; }

    private Ball ball;

    private Vector3 startPos;
    private float startTime;

    // Use this for initialization
    void Start () {
        ball = GetComponent<Ball>();
        GameEnd = false;
	}

    public void DragStart()
    {
        if (!ball.IsLaunched && !GameEnd)
        {
            startPos = Input.mousePosition;
            startTime = Time.realtimeSinceStartup;
        }
    }

    public void DragEnd()
    {
        if (!ball.IsLaunched && !GameEnd)
        {
            Vector3 endPos = Input.mousePosition;
            Vector3 offset = endPos - startPos;

            float endTime = Time.realtimeSinceStartup;
            float timeTaken = endTime - startTime;

            ball.Launch(new Vector3(offset.x, 0, offset.y) / timeTaken);
        }
    }

    public void MoveStartPosition(float x)
    {
        if (!ball.IsLaunched)
        {
            ball.Translate(new Vector3(x, 0, 0));            
        }
    }

}


