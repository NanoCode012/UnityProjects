using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Defender))]
public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public GameObject projectileStartingPosition;

	private GameObject projectileParent;

	private Animator animator;

    private Transform myLaneSpawnerTransform = null;

    private void Start()
    {
        animator = GetComponent<Animator>();

        projectileParent = GameObject.Find("Projectiles");
        if (projectileParent == null)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
    }

    private void Update()
	{
		if (HasAttackerInFront())
        {
            AttackStart();
        }
        else
        {
            AttackStop();
        }
	}

    private void SetMyLaneSpawner()
    {
        Transform spawners = FindObjectOfType<AttackerSpawner>().GetComponent<Transform>();
        foreach(Transform childSpawner in spawners)
        {
            if (Math.Abs(childSpawner.position.y - transform.position.y) < 0.1)
            {
                myLaneSpawnerTransform = childSpawner;
                break;
            }
        }

        if (myLaneSpawnerTransform == null) Debug.LogError(name + "'s lane spawner cannot be found");
    }

    private bool HasAttackerInFront()
    {
        int amountOfAttackers = myLaneSpawnerTransform.childCount;
        if (amountOfAttackers <= 0) return false;

		float currentDefenderXPosition = transform.position.x;
        foreach(Transform attacker in myLaneSpawnerTransform)
        {
            if (attacker.position.x <= 11 && attacker.position.x >= currentDefenderXPosition)
            {
                return true;
            }
        }
        return false;
    }

    private void AttackStart()
    {
        animator.SetBool("isAttacking", true);
    }

    private void AttackStop()
    {
        animator.SetBool("isAttacking", false);
    }

    private void ShootProjectile()
    {
        var myProjectile = Instantiate(projectile);

		myProjectile.transform.SetParent(projectileParent.transform);
        myProjectile.transform.position = projectileStartingPosition.transform.position;
    }
}
