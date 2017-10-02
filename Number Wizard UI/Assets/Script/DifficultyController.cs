using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyController : MonoBehaviour {

	public Text AI_Reply;
	public Text play;
	public static int max;
	public static int max_guess;
	private Color brown = new Color (0.914F, 0.588F, 0.478F);

	// Use this for initialization
	void Start () {
		AI_Reply.text = string.Empty;
		AI_Reply.color = Color.white;
		play.text = string.Empty;
	}

	public void Weak() {
		AI_Reply.color = Color.white;
		AI_Reply.text = "Alright, sheesh.. I'll go easy! \n Pick a number between 1-1000";
		SetMax (1000, 12);
		//max = 1000;
		//max_guess = 12;
		Show_self ();
	}

	public void Average() {
		AI_Reply.color = brown;
		AI_Reply.text = "Hmmm a challenger of fate! Gladly \n Pick a number between 1-100";
		SetMax (100, 8);
		//max = 100;
		//max_guess = 8;
		Show_self();
	}

	public void Unbeatable(){
		AI_Reply.text = "WHAT DID YOU SAYY!! \n Pick your filthy number between 1-10";
		AI_Reply.color = Color.red;
		SetMax (10, 7);
		//max = 10;
		//max_guess = 7;
		Show_self();
	}
	// Update is called once per frame
	void Update () {
		//print (max);
		//print (max_guess);
	}

	void Show_self(){
		play.text = "Play";
	}

	public static void SetMax(int a, int b){
		DifficultyController.max = a;
		DifficultyController.max_guess = b;
	}

}
