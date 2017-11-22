using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour {

    public enum Difficulty
    {
        easy = 0,
        normal = 1,
        hard = 2,
        god = 3
    }
    static Difficulty mode = Difficulty.easy;

    int timesToActivate = 10;


    void Start()
    {
        
        StartCorrespondingFunction();
    }

    void StartCorrespondingFunction()
    {
		switch (mode)
		{
			case Difficulty.easy:
                EasyDifficulty();
				break;
			case Difficulty.normal:
                NormalDifficulty();
				break;
			case Difficulty.hard:
                HardDifficulty();
				break;
			case Difficulty.god:
                GodDifficulty();
				break;
		}
    }

    public void Easy() {
        mode = Difficulty.easy;

    }

    public void Normal() {
        mode = Difficulty.normal;
    }

    public void Hard(){
        mode = Difficulty.hard;
    }

	public void ActivateGod()
	{
		timesToActivate--;
		if (timesToActivate <= 0)
		{
			God();
			timesToActivate = 10;
		}
	}

    void God(){
		mode = Difficulty.god;
    }

	void EasyDifficulty()
	{
        
	}

	void NormalDifficulty()
	{
        
	}

	void HardDifficulty()
	{
        
	}


	void GodDifficulty()
	{
        
	}

}
