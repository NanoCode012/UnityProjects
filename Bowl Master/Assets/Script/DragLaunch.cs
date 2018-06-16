using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;

    private Vector3 startPos;
    private float startTime;

    // Use this for initialization
    void Start () {
        ball = GetComponent<Ball>();
	}

    public void DragStart()
    {
        startPos = Input.mousePosition;
        startTime = Time.realtimeSinceStartup;
    }

    public void DragEnd()
    {
        Vector3 endPos = Input.mousePosition;
        Vector3 offset = endPos - startPos;

        float endTime = Time.realtimeSinceStartup;
        float timeTaken = endTime - startTime;

        ball.Launch(new Vector3(offset.x, 0, offset.y) / timeTaken);
    }

}


