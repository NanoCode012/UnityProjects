using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;

    MusicPlayer musicPlayer;

    int timesToActivate = 10;

    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        if (CheckIfMissingPlayer(musicPlayer))
        {
            SetValuesByPrefs();
        }
    }

    void SetValuesByPrefs()
    {
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
        musicPlayer.ChangeVolume(volumeSlider.value);
    }

    bool CheckIfMissingPlayer(MusicPlayer player)
    {
        if (!player)
        {
            Debug.LogWarning("Error MusicPlayer not found. Specifically MusicPlayer.cs component is missing/gone. " +
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
        SetValuesByPrefs();
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
