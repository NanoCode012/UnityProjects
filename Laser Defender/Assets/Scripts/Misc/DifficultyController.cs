using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyController : MonoBehaviour {

    public enum Difficulty
    {
        easy = 0,
        normal = 1,
        hard = 2,
        god = 3
    }
    Difficulty difficulty;
    void Start()
    {
		StartCorrespondingFunction();
    }

    void StartCorrespondingFunction()
    {
		switch (difficulty)
		{
			case Difficulty.easy:
				Easy();
				break;
			case Difficulty.normal:
				Normal();
				break;
			case Difficulty.hard:
				Hard();
				break;
			case Difficulty.god:
				God();
				break;
		}
    }

    public void Easy() {
        difficulty = Difficulty.easy;

    }

    public void Normal() {
        difficulty = Difficulty.normal;
    }

    public void Hard(){
        difficulty = Difficulty.hard;
    }
	
    public void God(){
		difficulty = Difficulty.god;
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
