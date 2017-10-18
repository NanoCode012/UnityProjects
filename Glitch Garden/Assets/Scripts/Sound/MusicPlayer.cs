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
            SceneManager.sceneLoaded += OnLevelLoaded;//subscribes to OnLevelLoaded(delegates)
		}
	}

    void OnLevelLoaded(Scene scene, LoadSceneMode loadsceneMode){
        PlayMusic(FindObjectOfType<LevelManager>().SceneBuildIndex());
    }

    void PlayMusic(int sceneIndex)
    {
        
        switch(sceneIndex)
        {
            case 0:
                if (music.clip == startClip) break;
                music.Stop();
                music.clip = startClip;
				music.loop = true;//Can't refactor this else, the break above will cause
                                  //maybe 2 AudioSource to run or cause a glitch.
                                  //haven't tested it yet, but highly likely sth will go wrong
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
