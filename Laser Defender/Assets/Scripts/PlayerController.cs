using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float x_speed = 3.5f;
    public float y_speed = 1.8f;
	// Use this for initialization
	void Start () {
		
	}
	
    /*
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(x_speed * Time.deltaTime, 0f, 0f);//moves x_speed per sec
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(x_speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0f, y_speed * Time.deltaTime, 0f);//moves y_speed per sec
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0f, y_speed * Time.deltaTime, 0f);
        }
	}
	*/

	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position -= new Vector3(x_speed, 0f, 0f);
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += new Vector3(x_speed, 0f, 0f);
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += new Vector3(0f, y_speed, 0f);
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position -= new Vector3(0f, y_speed, 0f);
		}
	}
}
