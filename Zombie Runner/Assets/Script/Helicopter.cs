using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public AudioClip heliCall;
    public AudioClip heliSound;

    private bool isCalled = false;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("CallHeli"))
        {
            isCalled = true;
            CallHelicopter();
        }
    }


    private void CallHelicopter()
    {
        if (audioSource.clip == null) audioSource.clip = heliCall;
        audioSource.Play();
    }
}
