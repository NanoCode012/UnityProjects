using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Defender))]
public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public GameObject projectileStartingPosition;

    private Animator animator;
	private GameObject projectileParent;
    private AttackerSpawner myLaneSpawner = null;

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
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            if (Math.Abs(spawner.gameObject.transform.position.y - transform.position.y) < 0.1)
            {
                myLaneSpawner = spawner;
                break;
            }
        }

        if (myLaneSpawner == null) Debug.LogError(name + "'s lane spawner cannot be found");
    }

    private bool HasAttackerInFront()
    {
        int amountOfAttackers = myLaneSpawner.gameObject.transform.childCount;
        if (amountOfAttackers <= 0) return false;

		float currentDefenderXPosition = transform.position.x;
        Transform myLaneSpawnerTransform = myLaneSpawner.transform;
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
