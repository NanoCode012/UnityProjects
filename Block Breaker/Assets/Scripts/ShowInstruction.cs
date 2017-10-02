using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInstruction : MonoBehaviour {

	public Text line0;
	public Text line1;
	public Text line2;
	public Text line3;
	// Use this for initialization
	void Start()
	{
		line0.text = string.Empty;
		line1.text = string.Empty;
		line2.text = string.Empty;
	}

	public void ShowLine2()
	{
		line0.text = "Seriously?!!";
		line1.text = "YES";
	}

	public void ShowLine3()
	{
		line2.text = "You make the ball...\n bounce";
		line3.text = "Thank you!";
	}

}
