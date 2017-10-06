using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float health = 160f;
    public GameObject acidBallEnemy;
    float speed = 6f;


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

    void Update()
    {
        if (Random.Range(0,20) == 1)//there is 1/20 chance to shoot per frame
        {
            Fire();
        }
    }

    void Fire()
    {
		var projectile = Instantiate(acidBallEnemy, transform.position, Quaternion.identity);
		projectile.GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
    }
}
