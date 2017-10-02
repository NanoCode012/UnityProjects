using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		print ("Level load requested for: " +name);
		//Application.LoadLevel(name);		obsolete
		SceneManager.LoadScene(name,LoadSceneMode.Single);

	}
	public void QuitLevel() {
		print("Quit level initiated");
		Application.Quit();
	}
}
