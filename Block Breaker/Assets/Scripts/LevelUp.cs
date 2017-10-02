using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelUp : MonoBehaviour {
    
    public void SkipLevel () {

        //GameObject.Find("SkipLevel").GetComponent<Button>().onClick.AddListener(CallNextLevel); 
        // ^ Why did I do this lol? I just made it loop to self. It works weirdly.
        //lamda expression =>
        //note call type has no () , just the method's name
		CallNextLevel();
    }



    void CallNextLevel()
    {
        var levelManager = FindObjectOfType<LevelManager>();
        levelManager.LoadNextLevel();
    }

}
