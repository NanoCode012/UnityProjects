using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
	// Use this for initialization
	void Start () {
        var enemy = Instantiate(enemyPrefab,transform.position,Quaternion.identity);
        enemy.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
