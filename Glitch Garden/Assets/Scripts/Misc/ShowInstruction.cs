using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInstruction : MonoBehaviour {

	public GameObject firstDefender;
    public GameObject secondDefender;
    public GameObject thirdDefender;
    public GameObject fourthDefender;

    public GameObject firstAttacker;
    public GameObject secondAttacker;
	// Use this for initialization
	void Start()
	{
        firstDefender.SetActive(PlayerPrefsManager.IsLevelUnlocked(5));
        secondDefender.SetActive(PlayerPrefsManager.IsLevelUnlocked(5));
        thirdDefender.SetActive(PlayerPrefsManager.IsLevelUnlocked(6));
        fourthDefender.SetActive(PlayerPrefsManager.IsLevelUnlocked(7));

        firstAttacker.SetActive(PlayerPrefsManager.IsLevelUnlocked(5));
        secondAttacker.SetActive(PlayerPrefsManager.IsLevelUnlocked(6));
	}
}
