using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range(0f, 3f)]
    private float currentSpeed;

	// Use this for initialization
	void Start () {
        Rigidbody2D myRigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody2D.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        print(name + " dealt " + damage + " damage");
    }
}
