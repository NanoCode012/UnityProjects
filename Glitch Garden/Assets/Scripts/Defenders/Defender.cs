using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
public class Defender : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
        print(name + " is touched by " + collision.name);
	}
}
