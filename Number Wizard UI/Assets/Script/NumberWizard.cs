using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;
	int max_guess;
	int current_guess;

	public Text guess_show;

	// Use this for initialization
	void Start () {
		/* Doesn't work because I didn't press at the exact time the game started. Could fix by adding more vars to check in Update event but lazy :P OR move it to Update() :O
		print ("++++++++++++++++++++++++++++++++++++++++++++");
		print ("Choose which range you want");
		print ("Press F1 for 1-100, F2 for 1-10000, F3 for 1-100000");

		if (Input.GetKeyDown (KeyCode.F1)) {
			max = 100;
			min = 1;
			StartGame ();
		} else if (Input.GetKeyDown (KeyCode.F2)) {
			max = 10000;
			min = 1;
			StartGame ();
		} else if (Input.GetKeyDown(KeyCode.F3)){
			max = 100000;
			min = 1;
			StartGame ();
		} else if (Input.GetKeyDown (KeyCode.Return)) {
			max = 1000;
			min = 1;
			StartGame ();
		}*/
		StartGame ();

	}

	void StartGame ()
	{
		//Max and min are changeable. Check Start() comment. Used like this to follow Number Wizard console
		max = DifficultyController.max;
		min = 1;
		guess = Random.Range(min,max);
		current_guess = 0;
		max_guess = DifficultyController.max_guess;
		guess_show.text = guess.ToString();
	}

	void NextGuess ()
	{
		if (current_guess >= max_guess) {
			SceneManager.LoadScene ("Lose");
		} else {
			if (max_guess != 7){
				guess = Random.Range(min, max+1); //pls rethink this +1 part, does it really include all 
				//the number only once? No, tested it, some number repeats but has all the numbers
			} else { guess = (min+max+1)/2;}
			guess_show.text = guess.ToString ();
		}
		//print (current_guess);


	}

	// Update is called once per frame
	void Update ()
	{
		//Debug.Log ("max : " +max);
		//Debug.Log ("min : " +min);
	}

	public void GuessHigher ()
	{
		min = guess;
		current_guess++;
		NextGuess ();
	}

	public void GuessLower ()
	{
		max = guess;
		current_guess++;
		if (guess == 2) {
			guess = 1;
		} else {
			NextGuess ();
		}
	}


}
