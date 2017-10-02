using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;
	public Text text;
	//int a; for test, check void Test ()

	// Use this for initialization
	void Start () {
		text.text = "I Am The God";
	/* Doesn't work because I didn't press at the exact time the game started. Could fix by adding more vars to check in Update event but lazy :P
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
		//int c = 0; for testing out declarations. can be deleted
		//Test();

	}
	/*
	void Test ()
	{
		random
		//print(a);
		int a = 10;
		print("PP:" + a);
		print("LL:" + this.a);
		//print("c :" + c);
	}*/

	void StartGame ()
	{
		max = 1000;
		min = 0;
		guess = Random.Range(min,max);

		print("============================================");
		print ("Welcome to NumberWizard!");
		print ("Pick a number in your head but don't tell me!");

		print ("The highest number you can pick is " +max+ ".");
		print ("The lowest number you can pick is " +min+ ".");

		max ++;

		print ("Is your number higher or lower than " +guess+ "?");
		print ("Up arrow for higher, Down for lower, Enter for equal");

	}

	void NextGuess ()
	{
		guess = (max + min) / 2;
		print ("Is your number higher or lower than " +guess+ "?");
		print ("Up arrow for higher, Down for lower, Enter for equal");
	}

	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			//print ("Up arrow pressed");
			min = guess;
			NextGuess();
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			//print ("Down arrow pressed");
			max = guess;
			NextGuess();
		}
		else if (Input.GetKeyDown (KeyCode.Return)) {
			print ("I won!!");
			StartGame();
		}
		
	}
}
