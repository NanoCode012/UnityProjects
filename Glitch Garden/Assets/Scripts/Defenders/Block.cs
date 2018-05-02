using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Defender))]
[RequireComponent (typeof(Animator))]
public class Block : MonoBehaviour {

    private Animator animator;

	private void Start()
	{
        animator = GetComponent<Animator>();
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.CompareTag("Attacker"))
        {
            Shake();
        }
    }

    private void Shake()
    {
        animator.SetTrigger("isAttackedTrigger");
	}
}
