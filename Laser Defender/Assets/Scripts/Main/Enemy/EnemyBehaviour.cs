using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float health = 160f;
    public GameObject acidBallEnemy;
    public float projectileSpeed = 5f;
    public int points = 1;

    public AudioClip collision;
    public AudioClip fireELaser;

    ScoreKeeper scoreKeeper;



    void Start()
    {
        //scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
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
            AudioSource.PlayClipAtPoint(collision, Camera.main.transform.position);
            if (health <= 0) {
                scoreKeeper.Score(points);
                Destroy(gameObject);
            }
        }
	}

    void Update()
    {
        if (Random.Range(0,40) == 1)//there is 1/20 chance to shoot per frame
        {
            Fire();
        }
    }

    void Fire()
    {
		var projectile = Instantiate(acidBallEnemy, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = Vector2.down * projectileSpeed;
        AudioSource.PlayClipAtPoint(fireELaser, Camera.main.transform.position);
    }
}
