using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
    
    public Slider angleSlider;
    public Slider powerSlider;
    public Text resultsTextComponent;

	public float gravity = -9.81f;
    public float scale = 100;

    private Rigidbody2D myRigidBody;

    private float startingXPosition;
    private float startingYPosition;

    private float timeFired;

    private bool isMoving = false;
    private bool canFire = true;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

        startingXPosition = transform.position.x;
        startingYPosition = transform.position.y;

        gravity /= scale;
	}

	private void Update()
	{
        if (isMoving)
        {
            if (transform.position.y < startingYPosition)
            {
                resultsTextComponent.text = "XDistFromOrigin : " + ((transform.position.x - startingXPosition) * scale) + "\n"
                                            + "TimeTaken : " + (Time.timeSinceLevelLoad - timeFired);
                myRigidBody.velocity = Vector2.zero;

                isMoving = false;            
            }

            myRigidBody.velocity += new Vector2(0, gravity * Time.deltaTime);
        }
	}

	public void Fire()
    {
        if (canFire)
        {
			float angle = angleSlider.value;
			float power = powerSlider.value;
			
			angle *= Mathf.Deg2Rad;
			
			myRigidBody.velocity = new Vector2(power * Mathf.Cos(angle) / scale , power * Mathf.Sin(angle) / scale);
			
			timeFired = Time.timeSinceLevelLoad;
			
            isMoving = true;
            canFire = false;
        }
    }

	public void Reset()
	{
        transform.position = new Vector3(startingXPosition, startingYPosition);
        myRigidBody.velocity = Vector2.zero;

        resultsTextComponent.text = "";

        isMoving = false;
		canFire = true;
	}
}
