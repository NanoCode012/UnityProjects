using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    float SplashScreenTime = 5.3f;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0){
            //Invoke("LoadNextLevel", SplashScreenTime);
            StartCoroutine(SplashScreen());
        }
    }

    IEnumerator SplashScreen(){
        yield return new WaitForSeconds(SplashScreenTime);
        LoadNextLevel();
    }

	public void LoadLevel(string name) {
		//print ("Level load requested for: " +name);
		SceneManager.LoadScene(name,LoadSceneMode.Single);
	}

	public void LoadNextLevel()
	{
        //print("Next level loaded");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
	}

    public int SceneBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void Lose()
    {
        LoadLevel("6_Lose");
    }

	public void QuitLevel() {
		print("Quit level initiated");
		Application.Quit();
	}

}
