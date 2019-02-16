using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public Text[] rollTexts;
    public Text[] frameTexts;

	// Use this for initialization
	void Start () {
		foreach(var text in rollTexts)
        {
            text.text = "";
        }
        foreach (var text in frameTexts)
        {
            text.text = "";
        }
	}
	
	public void FillRollCard(List<int> rolls)
    {
        rollTexts[-1].text = "0";
    }
}
