using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range(0f, 3f)]
    public float walkSpeed;


	// Use this for initialization
	void Start () {
        Rigidbody2D rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
	}
}
