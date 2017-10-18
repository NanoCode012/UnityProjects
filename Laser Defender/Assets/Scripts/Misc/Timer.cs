using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {


    public static float timePassed;

    PlayerController player;
    EnemySpawner enemySpawn;

    void Awake() {
        timePassed = 0f;

        player = FindObjectOfType<PlayerController>();
        player.enabled = false;

        enemySpawn = FindObjectOfType<EnemySpawner>();
        enemySpawn.enabled = false;

        Destroy(gameObject, 7f);
    }
	void Update () {
        timePassed += Time.deltaTime;
        if (timePassed >= 5f)
        {
            enemySpawn.enabled = true;
        }else if (timePassed >= 2f)
        {
            player.enabled = true;
        }
	}
}
