using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableButton : MonoBehaviour {

    public static SelectableButton selectedButton = null;
    public GameObject defenderPrefab;

    private SpriteRenderer spriteRenderer;

	private void Start()
	{
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black;
	}

    private void OnMouseDown()
    {
        if (selectedButton == null)
        {
            SetActive(true);
        }
        else if (selectedButton == this)
        {
            SetActive(false);
        }
        else
        {
            selectedButton.SetActive(false);
            SetActive(true);
        }
	}

    public void SetActive(bool isActive)
    {
        if (isActive)
        {
            spriteRenderer.color = Color.white;
            selectedButton = this;
        }
        else
        {
            spriteRenderer.color = Color.black;
            selectedButton = null;
        }
    }

    public GameObject GetDefender()
    {
        SetActive(false);
        return defenderPrefab;
    }

}
