using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Angle : MonoBehaviour {
    
    RectTransform rectTransform;
    // Use this for initialization
    void Start () {
        rectTransform = GetComponent<RectTransform>();
    }

    public void AdjustRotation(float angle)
    {
		rectTransform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    public void AdjustSize(float power)
    {
        rectTransform.localScale = new Vector3(power, rectTransform.localScale.y, rectTransform.localScale.z);
    }
}

