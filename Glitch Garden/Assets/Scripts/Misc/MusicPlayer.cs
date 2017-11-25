using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    public AudioClip[] audioClips;
    AudioSource audioSource;

    void Awake(){
        audioSource = GetComponent<AudioSource>();
        PlayAudio();

        SceneManager.sceneLoaded += OnLevelLoaded;
        DontDestroyOnLoad(gameObject);
    }

    void OnLevelLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        PlayAudio();
    }

    void PlayAudio()
    {
        var newClip = audioClips[SceneManager.GetActiveScene().buildIndex];
        if (audioSource.clip != newClip){
            audioSource.clip = newClip;
            audioSource.Play();
        }
    }

    public void ChangeVolume(float volume){
        audioSource.volume = volume;
    }
}
