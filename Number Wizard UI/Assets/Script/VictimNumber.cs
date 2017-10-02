using UnityEngine;
using UnityEngine.UI;
using System;

public class VictimNumber : MonoBehaviour {

	int random_victim = 0;
	//string random_victim_show = string.Empty;	use it if you want to Debug

	public Text start_title;

	//Initiate
	void Start () {
		
		random_victim = UnityEngine.Random.Range (100, 1000);
		//random_victim_show = random_victim.ToString(); use it if you want to Debug
		start_title.text = "Good MuRRAH, \n my " +random_victim+ "th victim!";
		/*This works too. Debug on string to int and backwards
		start_title.text = "Good MuRRAH, \n my " +random_victim_show+ "th victim!";
		print (random_victim);
		print (random_victim_show);
		string animal = "32";
		int x = Int32.Parse (animal);
		print (x);*/

		DifficultyController.SetMax (1000,12);
		int a = 11 / 2;
		print (a);
	}
		
}
