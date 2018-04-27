using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : Attacker {

	public override void OnTriggerEnter2D(Collider2D collision)
	{
        GameObject obj = collision.gameObject;

        if (obj.CompareTag("Defender") || obj.CompareTag("Block"))
        {
            AttackStart(obj);
        }
	}
}
