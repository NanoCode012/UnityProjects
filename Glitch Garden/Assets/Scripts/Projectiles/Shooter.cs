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
        if (projectileParent)
        {
			myProjectile.transform.SetParent(projectileParent.transform);
        }
        else
        {
            Debug.LogWarning("Could not find 'Projectiles' GameObject");
        }

        myProjectile.transform.position = projectileStartingPosition.transform.position;
    }
}
