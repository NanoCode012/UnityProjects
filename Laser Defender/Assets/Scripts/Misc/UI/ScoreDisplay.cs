using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	void Start () {
        GetComponent<Text>().text = ScoreKeeper.score.ToString();
        ScoreKeeper.Reset();
	}
	
}
