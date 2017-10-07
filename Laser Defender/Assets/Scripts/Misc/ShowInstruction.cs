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
		line0.text = "Up/Down Arrow keys to move\nup and down";
		line1.text = "Yes!";
	}

	public void ShowLine3()
	{
		line2.text = "and hold Space to Fire!";
		line3.text = "Thank you!";
	}

}
