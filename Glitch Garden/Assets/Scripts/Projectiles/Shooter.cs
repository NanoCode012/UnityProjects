using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public GameObject projectileStartingPosition;

	private GameObject projectileParent;

    private void ShootProjectile()
    {
        var myProjectile = Instantiate(projectile);

        projectileParent = GameObject.Find("Projectiles");
        if (projectileParent == null)
        {
            projectileParent = new GameObject("Projectiles");
        }

		myProjectile.transform.SetParent(projectileParent.transform);
        myProjectile.transform.position = projectileStartingPosition.transform.position;
    }

}
