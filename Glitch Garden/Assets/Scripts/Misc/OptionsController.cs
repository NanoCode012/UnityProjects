using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;

    MusicPlayer musicPlayer;

    int timesToActivate = 10;

    private void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        if (CheckIfMissingPlayer(musicPlayer))
        {
            UpdateValuesByPrefs();
        }
    }

    private void UpdateValuesByPrefs()
    {
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        musicPlayer.ChangeVolume(volumeSlider.value);

		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    public static bool CheckIfMissingPlayer(MusicPlayer player)
    {
        if (!player)
        {
            Debug.LogWarning("MusicPlayer not found. Specifically MusicPlayer.cs component is missing/gone. " +
                             "Did you start in the correct scene? Splash Scene? Debug : " + player);
        }
        return (bool)(player);
    }

    public void SaveValues()
    {
        var volume = volumeSlider.value;
        PlayerPrefsManager.SetMasterVolume(volume);
        musicPlayer.ChangeVolume(volume);

        PlayerPrefsManager.SetDifficulty((int)difficultySlider.value);
    }

    public void ResetValues()
    {
        PlayerPrefsManager.SetDefault();
        UpdateValuesByPrefs();
    }

    public void ActivateGod()
    {
        timesToActivate--;
        if (timesToActivate <= 0)
        {
            PlayerPrefsManager.SetDifficulty(4);
            timesToActivate = 10;
        }
    }
}
