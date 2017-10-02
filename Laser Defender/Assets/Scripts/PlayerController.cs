using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float x_speed = 3.7f;
    float y_speed = 2.3f;
    float padding = 0.6f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
 
	void Start () {
        //distance from player to camera
        var distance = transform.position.z - Camera.main.transform.position.z;

        //viewport(0,0) is bottom-left, (1,1) is top-right
        var bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        //automatically set values independant of screen size
        xMin = bottomLeft.x + padding;
        xMax = topRight.x - padding;
        yMin = bottomLeft.y + padding;
        yMax = topRight.y - padding;
	}

	void FixedUpdate()//for smoother movement, 0.02s per frame I believe
	{
        //allows diagonal movement
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

        //clamps player inside screen
		var newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        var newY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(newX, newY, transform.position.z);

	}
}
