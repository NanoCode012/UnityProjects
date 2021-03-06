﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string HAS_RAN_ONCE_KEY = "has_ran_once";
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    //Startup control
    private static void SetRanOnce()
    {
        PlayerPrefs.SetInt(HAS_RAN_ONCE_KEY, 1);
        SetDefault();
    }

    private static bool GetIfRanOnce()
    {
        return (PlayerPrefs.GetInt(HAS_RAN_ONCE_KEY) == 1);
    }
	
    //Volume control

    public static void SetMasterVolume(float volume){
        if (0f <= volume && volume <= 1f){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }else{
            Debug.LogError("Volume cannot be set out of range. Only within 0->1f. You input " + volume);
        }
    }

    public static float GetMasterVolume(){
        if (!GetIfRanOnce()) SetRanOnce();

        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    //Level control

    public static void UnlockCurrentLevel()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        UnlockLevel(level);
    }
     
    public static void UnlockLevel(int level, bool unlock = true){
        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            PlayerPrefs.SetInt(LEVEL_KEY + level, (unlock) ? 1 : 0);//1 true, 0 false
        }
        else {
            Debug.LogError("Cannot UnlockLevel higher than count of scenes. Only within 0->sceneCount - 1. You input " + level);
        }
    }

    public static bool IsLevelUnlocked(int level){
        if (0 <= level && level <= SceneManager.sceneCountInBuildSettings - 1) {
			return (PlayerPrefs.GetInt(LEVEL_KEY + level) == 1);
        }else {
            Debug.LogError("Cannot check levelUnlock on scenes higher than count of scenes  or lower than 0. Only within 0->sceneCount - 1. You input " + level);
            return false;
        }
    }

    //Difficulty control

    public static void SetDifficulty(int difficulty){
        if (1 <= difficulty && difficulty <= 4) {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        }else {
            Debug.LogError("Difficulty cannot be set out of range. Only within 1->3. You input " + difficulty);//1 easy, 2 normal, 3 hard, 4 god
        }
    }

    public static int GetDifficulty(){
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }

    //Reset control

    public static void SetDefault(){
        SetMasterVolume(0.36f);
        SetDifficulty(1);

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            UnlockLevel(i, false);
        }
    }
}
