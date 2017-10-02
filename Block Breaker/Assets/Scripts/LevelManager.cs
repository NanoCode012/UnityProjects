using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		//print ("Level load requested for: " +name);
        Brick.breakableCount = 0;//for safety
		SceneManager.LoadScene(name,LoadSceneMode.Single);

	}

	public void LoadNextLevel()
	{
        //print("Next level loaded");
        Brick.breakableCount = 0;//for safety
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1,LoadSceneMode.Single);

	}

	public void QuitLevel() {
		print("Quit level initiated");
		Application.Quit();
	}

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
