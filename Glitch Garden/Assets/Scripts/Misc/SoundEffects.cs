using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {
	
    public static void PlayFX(AudioClip audioClip)
    {
        float volume = PlayerPrefsManager.GetMasterVolume();
        Vector3 position = new Vector3(0, 0, 0);

        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
}
