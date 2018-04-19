using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
        print(name + " is touched by " + collision.name);
	}
}
