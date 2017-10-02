using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
		//levelManager = (LevelManager)FindObjectOfType(typeof(LevelManager));//same as above
    }
    void OnTriggerEnter2D(Collider2D trigger){
		print ("Lost!");
		levelManager.LoadLevel ("Lose"); 
	}
}
