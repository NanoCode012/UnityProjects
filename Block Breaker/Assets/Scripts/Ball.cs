using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    Paddle paddle;
    Vector3 ballToPaddleVector;
    bool hasStarted;
    public float dir;
    public float vspeed;
    AudioSource audioSource;
    public Vector2 tweak;
    void Start () {
        paddle = FindObjectOfType<Paddle>();
        ballToPaddleVector = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();

    }

    void Update () {
        if (!hasStarted)
        {
            transform.position = paddle.transform.position + ballToPaddleVector;

            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(dir, vspeed);
                hasStarted = true;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted == true)
        {
            if (!SoundController.mute)
            {
                audioSource.Play();//play boing fx
            }
            ChangeDirPerCollision();
            //print("Added tweak " + tweak.ToString());
            if (collision.gameObject.name == "Paddle" && System.Math.Abs(GetComponent<Rigidbody2D>().velocity.x) <= 0.5f)
            //add dificulty to game, and to not let ball keep going up and down forever
            {
                BreakStalemate();
                //print("Added x-force " + force.ToString());
            }

        }
    }

    void ChangeDirPerCollision()
    {
        GetComponent<Rigidbody2D>().AddForce(tweak);
    }

    void BreakStalemate()
    {
        var force = new Vector2(Random.Range(-3f, 3f), 0);
		GetComponent<Rigidbody2D>().AddForce(force);
		//GetComponent<Rigidbody2D>().velocity += force;//same as above line, maybe not the same. Force != velocity
	}
}
