using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daycycle : MonoBehaviour
{

    public float timeScale = 60;

    public bool isDay = true;
    float increment;

    private Quaternion startRotation;
    // Start is called before the first frame update
    void Start()
    {
        increment =  360 / timeScale;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isDay) transform.eulerAngles = new Vector3(30, -30, 0);
        //else transform.eulerAngles = new Vector3(220, -30, 0);

        //0->86400 s/day
        //0->360 degree
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x + increment/Time.deltaTime, transform.eulerAngles.y, transform.eulerAngles.z);
        transform.RotateAround(transform.position, Vector3.forward, Time.deltaTime / increment);
    }
}
