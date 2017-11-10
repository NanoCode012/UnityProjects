using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer instance;

    public AudioClip splashScreenClip;
    public AudioClip startScreenClip;

    AudioSource music;

	void Awake(){
		if (instance != null && instance != this) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
            music = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnLevelLoaded;//subscribes to OnLevelLoaded(delegates)
		}
	}

    void OnLevelLoaded(Scene scene, LoadSceneMode loadsceneMode){
        PlayMusic(FindObjectOfType<LevelManager>().SceneBuildIndex());
    }

    void PlayMusic(int sceneIndex)
    {

        switch (sceneIndex)
        {
            case 0:
                music.clip = splashScreenClip;
                break;
            case 1:
                if (music.clip == startScreenClip) break;
                music.Stop();
                music.clip = startScreenClip;
                break;
        }
        music.loop = true;
        music.Play();
    }
}
