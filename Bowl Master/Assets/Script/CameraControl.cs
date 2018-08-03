using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Ball ball;

    private Vector3 offset;
    private const float positionOfFirstPin = 1829f;
    private readonly float positionToStopAt = positionOfFirstPin - 100;

	// Use this for initialization
	void Start () {
        offset = ball.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (ball.transform.position.z < positionToStopAt)
        {
            transform.position = ball.transform.position - offset;
        }
	}
}
