using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    private Camera camera;
    private float defaultFOV;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        defaultFOV = camera.fieldOfView;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Zoom"))
        {
            camera.fieldOfView /= 1.5f;
        }
        else if (Input.GetButtonUp("Zoom"))
        {
            camera.fieldOfView = defaultFOV;
        }
    }

    
}
