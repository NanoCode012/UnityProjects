using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

    private MusicPlayer musicPlayer;
	// Use this for initialization
	void Start () 
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        if (!(musicPlayer))
        {
            Debug.LogWarning("Error MusicPlayer not found. Specifically MusicPlayer.cs component is missing/gone. " +
                             "Did you start in the correct scene? Splash Scene? Debug : " + musicPlayer);
        }
        else
        {         
			musicPlayer.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
        }
    }
}
