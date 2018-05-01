using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

    private MusicPlayer musicPlayer;
	// Use this for initialization
	void Start () 
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        if (OptionsController.CheckIfMissingPlayer(musicPlayer))
        {
            musicPlayer.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
        }
    }
}
