using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer instance;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    AudioSource music;

	void Awake(){
		if (instance != null && instance != this) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
            music = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnLevelLoaded;
		}
	}

    void OnLevelLoaded(Scene scene, LoadSceneMode loadsceneMode){
        PlayMusic(FindObjectOfType<LevelManager>().SceneBuildIndex());
    }

    void PlayMusic(int index)
    {
        
        switch(index)
        {
            case 0:
                if (music.clip == startClip) break;
                music.Stop();
                music.clip = startClip;
				music.loop = true;
				music.Play();
                break;
            case 4:
                music.Stop();
                music.clip = gameClip;
				music.loop = true;
				music.Play();
                break;
            case 6:
                music.Stop();
                music.clip = endClip;
				music.loop = true;
				music.Play();
                break;
        }

    }

}
