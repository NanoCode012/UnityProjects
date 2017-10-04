using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float health = 160f;

	void OnTriggerEnter2D(Collider2D col)
	{
        var projectile = col.GetComponent<Projectile>();
        if (projectile)//it seems this takes slightly more time
        //if (col.gameObject.name == "AcidBallClone)")//this is slightly faster but 
                                                      //What if there is more types of projectile? 
                                                      //This line won't cover it like the one above
        {
            health -= projectile.GetDamage();
            projectile.Hit();
            if (health <= 0) Destroy(gameObject);
        }
	}
}
