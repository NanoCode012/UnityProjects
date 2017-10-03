using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
	// Use this for initialization
	void Start () {
        foreach (Transform transf in transform)
        {
            var enemy = Instantiate(enemyPrefab, transf.position, Quaternion.identity);
            enemy.transform.parent = transf;
        }

        //Another method could be done using the below(I made the below, but it takes twice as long to process)
		//var enemyPostions = FindObjectsOfType<Position>();
		//foreach (var pos in enemyPostions)
		//{
		//	var enemy = Instantiate(enemyPrefab, pos.transform.position, Quaternion.identity);
		//	enemy.transform.parent = pos.transform;
		//}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
