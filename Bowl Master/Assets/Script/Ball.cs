using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class Ball : MonoBehaviour {

    public AudioClip rollingClip;

    [SerializeField] private float initialVelocity = 3f;
    private Rigidbody myRigidBody;
    private AudioSource audioSource;

	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.velocity = Vector3.forward * (initialVelocity);

        if (rollingClip == null) Debug.LogWarning("Ball's rollingClip is missing!");

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = rollingClip;
        audioSource.loop = true;
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
