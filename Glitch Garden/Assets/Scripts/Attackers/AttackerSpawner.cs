using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    public GameObject[] attackerPrefab;

	void Update () {
        foreach(GameObject attacker in attackerPrefab)
        {
            if (isTimeToSpawn(attacker))
            {
                Spawn(attacker);
            }
        }
	}

    void Spawn(GameObject myGameObject)
    {
        GameObject attacker = Instantiate(myGameObject);
        attacker.transform.SetParent(transform);
        attacker.transform.position = transform.position;

        print("Spawning " + myGameObject.name);
    }

    bool isTimeToSpawn(GameObject myGameObject)
    {
        float spawnTime = myGameObject.GetComponent<Attacker>().timeToSpawn;
        if (Time.deltaTime > spawnTime)
        {
            Debug.LogWarning("Spawn capped by frame-rate. SpawnTime cannot be less than " + Time.deltaTime);
        }
        //Get random value between 0.0-1.0 , Check if lower than the chance of Spawn per second per lane
        //independant from frame-rate
        return (Random.value < ((1 / spawnTime) * Time.deltaTime / 5));
    }
}
