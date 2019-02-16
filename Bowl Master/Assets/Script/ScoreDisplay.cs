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
	
	public void FillRolls(List<int> rolls)
    {
        string scoreString = FormatRolls(rolls);
        int length = scoreString.Length;
        for (var i = 0; i < length; i++)
        {
            rollTexts[i].text = scoreString[i].ToString();
        }
    }

    public void FillFrames(List<int> frames)
    {
        int count = frames.Count;
        for (var i = 0; i < count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string res = "";

        int frame = 0;
        int count = rolls.Count;
        for (int i = 0; i < count; i++,frame++)
        {
            if (rolls[i] == 0) res += "-";
            else if (frame % 2 == 0 && rolls[i] == 10)
            {
                res += "X";
                if (frame < 18) res += " ";
                frame++;
            }
            else if (frame % 2 != 0 && rolls[i] + rolls[i - 1] == 10 && frame < 20) res += "/";
            else res += rolls[i];
        }

        return res;
    }
}
