using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour {

    public static bool mute;
    public Text text;
    MusicPlayer musicPlayer;
    void Start()
    {
        CheckIfMissing();
		musicPlayer = FindObjectOfType<MusicPlayer>();
        ChangeText();
    }

    public void MuteUnmute()
    {
        musicPlayer.GetComponent<AudioSource>().mute = !musicPlayer.GetComponent<AudioSource>().mute;
		ChangeText();
    }

    void ChangeText()
    {
		if (musicPlayer.GetComponent<AudioSource>().mute)//if no sound
		{
			text.text = "Enable";
            mute = true;
		}
		else
		{
			text.text = "Disable";
            mute = false;
		}
    }

    void CheckIfMissing()
    {
        if (!FindObjectOfType<MusicPlayer>())
		{
            Debug.LogWarning("Error MusicPlayer not found. Specifically StayAwake component is gone. " +
                             "Did you start in the correct scene? Start Scene. Debug : " + FindObjectOfType<MusicPlayer>());
		}
    }
}
