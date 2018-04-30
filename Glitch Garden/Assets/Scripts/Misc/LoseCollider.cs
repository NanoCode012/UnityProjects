using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

	private void Start()
	{
        levelManager = FindObjectOfType<LevelManager>();
        if (levelManager == null)
        {
            Debug.LogWarning("Level Manager not found. Did you attach it to the script?");
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        levelManager.Lose();
	}
}
