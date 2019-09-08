using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject SpawnPointParent;

    [SerializeField] private bool callRespawn = false;

    private Transform playerTransform;
    private Transform[] spawnPoints;
    private readonly System.Random rand = new System.Random();


    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = SpawnPointParent.GetComponentsInChildren<Transform>();
        playerTransform = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (callRespawn)
        {
            Respawn();
            callRespawn = false;
        }
    }

    void Respawn()
    {
        playerTransform.position = spawnPoints[rand.Next(spawnPoints.Length)].position;
    }
}
