using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    public AudioClip[] audioClips;
    AudioSource audioSource;

    private void Awake(){
        audioSource = GetComponent<AudioSource>();
        PlayAudio();

        SceneManager.sceneLoaded += OnLevelLoaded;
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        PlayAudio();
    }

    private void PlayAudio()
    {
        var newClip = audioClips[SceneManager.GetActiveScene().buildIndex];
        if (audioSource.clip != newClip){
            audioSource.clip = newClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void PauseAudio()
    {
        audioSource.Pause();
    }

    private void UnPauseAudio()
    {
		audioSource.UnPause();
    }

    public void ChangeVolume(float volume){
        audioSource.volume = volume;
    }

    public void PlayFX(AudioClip audioClip, float bufferTimeBeforeResumingMusic = 3f)
    {
        audioSource.clip = audioClip;
        audioSource.loop = false;
        audioSource.Play();

        StartCoroutine(ResumePlayingAfterSeconds(audioClip.length + bufferTimeBeforeResumingMusic));
    }

    IEnumerator ResumePlayingAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        PlayAudio();
    }
}
