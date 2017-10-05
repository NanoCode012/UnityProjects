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
    public float health = 500;

	public bool useMouse;

    public GameObject acidball;
	float fireRate = 0.33f;//higher value means fire slower
    Camera mainCamera = new Camera();
    LevelManager levelManager;
 
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
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

	void Update()
	{
        
        //allows mouse control
        if (useMouse)
        {
            MouseMovement();
        }
        else
        {
            KeyboardMovement();

			//Auto-Fire
			if (Input.GetKeyDown(KeyCode.Space))
			{
			    InvokeRepeating("Fire", 0.000001f, fireRate);
			}
			if (Input.GetKeyUp(KeyCode.Space))
			{
			    CancelInvoke("Fire");
			}
        }
    }

    void KeyboardMovement()
    {
        //allows diagonal movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * x_speed * Time.deltaTime;//moves x_speed per sec
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * x_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * y_speed * Time.deltaTime;//moves y_speed per sec
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * y_speed * Time.deltaTime;
        }

        //clamps player inside screen
        var newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        var newY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    void MouseMovement()
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);//Screen is GUI
        var posX = Mathf.Clamp(mousePos.x, xMin, xMax);
        var posY = Mathf.Clamp(mousePos.y, yMin, yMax);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }

    void Fire()
    {
		var projectile = Instantiate(acidball, transform.position, Quaternion.identity);
		projectile.GetComponent<Rigidbody2D>().velocity = Vector2.up * x_speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        var projectile = col.GetComponent<EnemyProjectile>();
        if (projectile)
        {
            health -= projectile.GetDamage();
            projectile.Hit();
            if (health <= 0) levelManager.LoadLevel("Lose");
        }
    }
}
