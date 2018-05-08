using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour {

    private BallController ballController;

	private void Start()
	{
        ballController = FindObjectOfType<BallController>();
	}

	public void Reset()
    {
        ballController.Reset();
    }
}
