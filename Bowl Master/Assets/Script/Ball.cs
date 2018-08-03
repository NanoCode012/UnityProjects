using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
[RequireComponent (typeof(Rigidbody))]
public class Ball : MonoBehaviour {

    public AudioClip rollingClip;

    public bool IsLaunched { get; private set; }

    private Rigidbody myRigidBody;
    private AudioSource audioSource;

    private Vector3 startPos;

	void Start () {
        IsLaunched = false;

        myRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        myRigidBody.useGravity = false;

        if (rollingClip == null) Debug.LogWarning("Ball's rollingClip is missing!");
        else
        { 
            audioSource.clip = rollingClip;
            audioSource.loop = true;
        }

        startPos = myRigidBody.position;
    }

    public void Translate(Vector3 displacement)
    {
        myRigidBody.position += displacement;
        if (myRigidBody.position.x < -50)
        {
            myRigidBody.position = new Vector3(-50, myRigidBody.position.y, myRigidBody.position.z);
        }
        else if (myRigidBody.position.x > 50)
        {
            myRigidBody.position = new Vector3(50, myRigidBody.position.y, myRigidBody.position.z);
        }
    }

    public void Launch(Vector3 velocity)
    {
        IsLaunched = true;

        myRigidBody.velocity = velocity;
        myRigidBody.useGravity = true;

        audioSource.Play();
    }

    public void Reset()
    {
        myRigidBody.position = startPos;
        
        myRigidBody.velocity = Vector3.zero;
        myRigidBody.angularVelocity = Vector3.zero;
        myRigidBody.useGravity = false;

        audioSource.Stop();
        IsLaunched = false;
    }
}
