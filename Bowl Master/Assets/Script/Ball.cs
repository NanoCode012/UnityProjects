using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
[RequireComponent (typeof(Rigidbody))]
public class Ball : MonoBehaviour {

    public AudioClip rollingClip;

    private Rigidbody myRigidBody;
    private AudioSource audioSource;

	void Start () {

        myRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        myRigidBody.useGravity = false;

        if (rollingClip == null) Debug.LogWarning("Ball's rollingClip is missing!");
        else
        { 
            audioSource.clip = rollingClip;
            audioSource.loop = true;
        }
    }

    public void Launch(Vector3 velocity)
    {
        myRigidBody.velocity = velocity;
        myRigidBody.useGravity = true;

        audioSource.Play();
    }
}
