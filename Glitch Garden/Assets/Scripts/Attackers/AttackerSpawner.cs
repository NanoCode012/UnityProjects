using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    [Tooltip("Array of attacker Prefabs")]
    public GameObject[] attackerPrefab;

    [Tooltip("Duration between appearances for each attacker")]
    public float[] timeToSpawn;

	private int amountOfAttackers;

	private void Start()
	{
        amountOfAttackers = attackerPrefab.Length;
	}

	void Update () {
        foreach(Transform childLane in transform)
        {
			for (int attackerIndex = 0; attackerIndex < amountOfAttackers; attackerIndex++)
			{
				if (IsTimeToSpawn(attackerIndex))
				{
                    Spawn(attackerIndex, childLane);
				}
			}
        }
	}

    void Spawn(int indexOfGameObject, Transform laneTransform)
    {
        GameObject myGameObject = attackerPrefab[indexOfGameObject];

        GameObject attacker = Instantiate(myGameObject);
        attacker.transform.SetParent(laneTransform);
        attacker.transform.position = laneTransform.position;

        print("Spawning " + myGameObject.name);
    }

    bool IsTimeToSpawn(int indexOfGameObject)
    {
        float spawnTime = timeToSpawn[indexOfGameObject];

        //Do not spawn
        if (spawnTime <= 0) 
        {
            return false;
        }

        if (Time.deltaTime > spawnTime)
        {
            Debug.LogWarning("Spawn capped by frame-rate. SpawnTime cannot be less than " + Time.deltaTime);
        }

        //Get random value between 0.0-1.0 , Check if lower than the chance of Spawn per second per lane
        //independant from frame-rate
        return (Random.value < (((1 / spawnTime) * Time.deltaTime) / 5));
    }
}
