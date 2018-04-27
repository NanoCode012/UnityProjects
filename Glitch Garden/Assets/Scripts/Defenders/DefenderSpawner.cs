using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    
    Camera mainCamera;
    GameObject defenderParent;

	private void Start()
	{
        mainCamera = Camera.main;
        defenderParent = GameObject.Find("Defenders");
        if (defenderParent == null)
        {
            defenderParent = new GameObject("Defenders");
        }
	}

	private void OnMouseDown()
	{
        if (SelectableButton.selectedButton != null)
        {
            GameObject defenderPrefab = SelectableButton.selectedButton.GetDefender();
            Vector2 position = SnapToGrid(CalculateMousePositionInWorldUnit());
            GameObject defender = Instantiate(defenderPrefab, position, Quaternion.identity);
			defender.transform.parent = defenderParent.transform;
        }
	}

    private Vector2 CalculateMousePositionInWorldUnit()
    {
        Vector2 mousePressed = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        return mousePressed;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        int newX = Mathf.RoundToInt(rawWorldPosition.x);
        int newY = Mathf.RoundToInt(rawWorldPosition.y);
        return new Vector2(newX, newY);
    }
}
