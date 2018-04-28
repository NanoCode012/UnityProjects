using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {

    public float speed;
    public float damage;

    private Rigidbody2D myRigidbody2D;

    private void Start()
    {
        myRigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody2D.isKinematic = true;
    }

    private void Update()
    {
        myRigidbody2D.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Attacker"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.DealDamage(damage);
            Destroy(gameObject);
        }
	}
}
