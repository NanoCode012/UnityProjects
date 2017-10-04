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
    public bool useMouse;
    public GameObject acidball;
    Camera mainCamera = new Camera();
 
	void Start () {
        mainCamera = Camera.main;
        //distance from player to camera
        var distance = transform.position.z - mainCamera.transform.position.z;

		//viewport(0,0) is bottom-left, (1,1) is top-right
        var bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, distance));
		var topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, distance));
		//commented out works too, this is just to try different ways of doing the same thing
		//var bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, distance));
		//var topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, distance));


		//automatically set values independant of screen size
		xMin = bottomLeft.x + padding;
        xMax = topRight.x - padding;
        yMin = bottomLeft.y + padding;
        yMax = topRight.y - padding;
	}

	void FixedUpdate()//for smoother movement, 0.02s per frame I believe
	{
        
        //allows mouse control
        if (useMouse)
        {
            var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);//Screen is GUI
            var posX = Mathf.Clamp(mousePos.x, xMin, xMax);
            var posY = Mathf.Clamp(mousePos.y, yMin, yMax);
            transform.position = new Vector3(posX, posY, transform.position.z);
        }
        else
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

            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(acidball, transform.position, Quaternion.identity);
            }
        }
	}
}
