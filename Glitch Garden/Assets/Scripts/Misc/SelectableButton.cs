using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableButton : MonoBehaviour {

    public static GameObject selectedButton = null;
    public GameObject defenderPrefab;

    SpriteRenderer spriteRenderer;
    //bool isPressed = false;

	private void Start()
	{
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black;
	}

	private void OnMouseEnter()
	{
        spriteRenderer.color = Color.white;
	}

	private void OnMouseDown()
	{
        selectedButton = defenderPrefab;
	}

	private void OnMouseExit()
	{
        spriteRenderer.color = Color.black;
        selectedButton = null;
	}

	private void OnMouseUp()
	{
        selectedButton = null;
	}
}
