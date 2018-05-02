using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class GameTimer : MonoBehaviour {

    public int levelDurationInSeconds = 100;

    public AudioClip winFX;

    public GameObject winStatement;

    private Slider slider;
    private LevelManager levelManager;

    private MusicPlayer musicPlayer;

	private bool isEndLevel = false;

	// Use this for initialization
	void Start () {
        winStatement.SetActive(false);

        slider = GetComponent<Slider>();
        slider.value = 0;
        slider.maxValue = levelDurationInSeconds;

        levelManager = FindObjectOfType<LevelManager>();

        musicPlayer = FindObjectOfType<MusicPlayer>();
        OptionsController.CheckIfMissingPlayer(musicPlayer);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isEndLevel)
        {
            slider.value += Time.deltaTime;
            if (slider.value >= levelDurationInSeconds)
			{
                StartCoroutine(WaitSecondsAndLoadNextLevel(winFX.length));
				isEndLevel = true;
            }
        }
	}

    IEnumerator WaitSecondsAndLoadNextLevel(float seconds)
    {
        float bufferTimeBeforeResumingMusic = 3f;

        musicPlayer.PlayFX(winFX, bufferTimeBeforeResumingMusic);

        winStatement.SetActive(true);

        yield return new WaitForSeconds(seconds + bufferTimeBeforeResumingMusic);

        PlayerPrefsManager.UnlockCurrentLevel();
        levelManager.LoadNextLevel();
    }
}
