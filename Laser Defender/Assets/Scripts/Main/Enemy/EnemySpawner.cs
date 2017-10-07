using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    float width = 5.65f;
    float height = 3.76f;
	float speed;
    const int divider = 200;
	float minX, maxX;

    bool dir;//true is left, false is right
    float spawnDelay = 0.8f;
	
	void Start ()
    {
        SpawnEnemyTillFullPosition();

        /*
        Another method could be done using the below(I made the below, but it takes twice as long to process)
        var enemyPostions = FindObjectsOfType<Position>();
        foreach (var pos in enemyPostions)
        {
        	var enemy = Instantiate(enemyPrefab, pos.transform.position, Quaternion.identity);
        	enemy.transform.parent = pos.transform;
        }
        */

        dir = (Random.Range(0, 2) == 0);
        var distToCamera = transform.position.z - Camera.main.transform.position.z;
        var bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distToCamera));
        var topRight = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, distToCamera));
        minX = bottomLeft.x;
        maxX = topRight.x;

        speed = Screen.width / divider;

    }

    void SpawnEnemyAtPosition()
    {
        foreach (Transform child in transform)
        {
            var enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity);
            enemy.transform.parent = child;
        }
    }

    void SpawnEnemyTillFullPosition()
    {
		//print("Being run");
        var freePosition = NextFreePosition();
        if (freePosition)
        {
            var ship = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity);
            ship.transform.parent = freePosition;
            Invoke("SpawnEnemyTillFullPosition", spawnDelay);
        }
        else CancelInvoke("SpawnEnemyTillFullPosition");

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width,height,0));
    }

    void FixedUpdate ()
    {
        AutoMovement();
    }

    void AutoMovement()
    {
        if (dir)//move left
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

        }
        else//move right
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float SpawnerLeftmost = minX + width / 2;
        float SpawnerRightmost = maxX - width / 2;
        if (transform.position.x <= SpawnerLeftmost)
        {
            dir = false;
        }
        else if (transform.position.x >= SpawnerRightmost)
        {
            dir = true;
        }
    }

    void Update()
    {
        if (AllMembersDead())
        {
            SpawnEnemyTillFullPosition();
            print("All dead");
        }
    }

    Transform NextFreePosition()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount == 0)
            {
                return child;
            }
        }
        return null;
    }

    bool AllMembersDead()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount == 1)
            {
                return false;
            }
        }
        return true;
    }
}
