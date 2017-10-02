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
    int timesClicked;
    int timesNeedToActivate = 10;
    bool hasBall;
    public static Difficulty difficulty = Difficulty.normal;
    GameObject levelUp;
    Ball ball;
    Paddle paddle;
    void Start()
    {
        levelUp = GameObject.FindWithTag("Cheat");//Do not change tag in Unity recklessly or this breaks
        // ^ I manually exposed it and connected via inspector. DO NOT CONNECT. IT DEACTIVATES SELF.
        if (FindObjectOfType<Ball>())
        {
			ball = FindObjectOfType<Ball>();
            paddle = FindObjectOfType<Paddle>();
            hasBall = true;
        }
        else
        {
            hasBall = false;
        }
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
        if (hasBall){
			EasyDifficulty();
        }
        levelUp.SetActive(false);
    }

    public void Normal() {
        difficulty = Difficulty.normal;
        if (hasBall){
			NormalDifficulty();
        }
        levelUp.SetActive(false);
    }

    public void Hard(){
        difficulty = Difficulty.hard;
        if (hasBall){
			HardDifficulty();
        }
        levelUp.SetActive(false);
    }
	
    public void ActivateGod(){
        timesClicked++;
        if (timesClicked >= timesNeedToActivate)
        {
            God();
            timesClicked = 0;
        }
    }

    public void God(){
		difficulty = Difficulty.god;
		if (hasBall)
		{
			GodDifficulty();
		}
		levelUp.SetActive(true);
    }

	void EasyDifficulty()
	{
		ball.dir = 3f;
		ball.vspeed = 11f;
		ball.tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        Paddle.autoplay = false;//autoplay off	
		//for normal detection
		paddle.gameObject.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        ball.gameObject.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
	}

	void NormalDifficulty()
	{
		ball.dir = Random.Range(-8f, 8f);
		ball.vspeed = 13f;
		ball.tweak = new Vector2(Random.Range(0f, 0.4f), Random.Range(0f, 0.4f));
		Paddle.autoplay = false;//autoplay off
        //for normal detection
		paddle.gameObject.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        ball.gameObject.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
	}

	void HardDifficulty()
	{
		ball.dir = Random.Range(-15f, 15f);
		ball.vspeed = 19f;
		ball.tweak = new Vector2(Random.Range(0f, 0.7f), Random.Range(0f, 0.7f));
        Paddle.autoplay = false;//autoplay off
        //for fast detection
        paddle.gameObject.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        ball.gameObject.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
	}

	void GodDifficulty()
	{
		ball.dir = 3f;
		ball.vspeed = 11f;
		ball.tweak = new Vector2(0.1f, 0.1f);
        Paddle.autoplay = true;//autoplay on
        //for normal detection
        paddle.gameObject.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        ball.gameObject.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
	}
}
