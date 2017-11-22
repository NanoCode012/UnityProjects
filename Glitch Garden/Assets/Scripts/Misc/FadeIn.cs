using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeTime = 2;
    Image panel;
    Color currentCol = Color.black;
	void Start () {
        panel = GetComponent<Image>();
        currentCol.a = 1f;
        panel.color = currentCol;
	}
	
	void Update () {
        if (Time.timeSinceLevelLoad < fadeTime){
            Fade();
        }else{
            gameObject.SetActive(false);
        }
    }

    void Fade(){
        currentCol.a -= Time.deltaTime / fadeTime;
        panel.color = currentCol;
    }
}
