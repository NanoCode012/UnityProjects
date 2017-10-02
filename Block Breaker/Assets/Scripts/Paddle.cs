using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public static bool autoplay;
    Ball ball;
	// Use this for initialization
	void Start () {
        ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (autoplay)
        {
            FollowBall();
        }
        else
        {
            FollowMouse();
        }
    }

    void FollowMouse ()
    {
		float mousePosInUnits = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, 0.5f, 15.5f);
		// ^ relative mouse position between 0-16 world units, clamp so fullblock sprite within screen
        //it is relative, so if we change screen width somewhere else, it won't break the code
		Vector3 paddlePos = new Vector3(mousePosInUnits, transform.position.y, transform.position.z);
		transform.position = paddlePos;
    }

    void FollowBall()
    {
        Vector3 ballPos = new Vector3(ball.transform.position.x, transform.position.y, transform.position.z);
		transform.position = ballPos;
    }

}
