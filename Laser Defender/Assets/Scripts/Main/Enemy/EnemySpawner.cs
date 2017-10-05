using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    float width = 5.65f;
    float height = 3.76f;
	float speed;
    const int divider = 200;//get from test
	float minX, maxX;

    bool dir;//false is left, true is right
	
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

        dir = (Random.Range(0, 2) == 0) ? false : true;

        var distToCamera = transform.position.z - Camera.main.transform.position.z;
        var bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f,distToCamera));
        var topRight = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f,distToCamera));
        minX = bottomLeft.x;
        maxX = topRight.x;

        speed = Screen.width / divider;

	}

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width,height,0));
    }

    void FixedUpdate () {
        if (!dir)//move left
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

		}
		else//move right
		{
            transform.position += Vector3.right * speed * Time.deltaTime;
		}

        float SpawnerLeftmost = minX + width / 2;
        float SpawnerRightmost = maxX - width / 2;
        if (transform.position.x <= SpawnerLeftmost) {
            dir = true;
        }else if (transform.position.x >= SpawnerRightmost){
            dir = false;
        }
	}
}
