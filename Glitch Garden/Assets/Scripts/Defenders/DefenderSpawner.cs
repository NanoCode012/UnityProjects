using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    
    private Camera mainCamera;

    private GameObject defenderParent;

    private StarDisplay starDisplay;

	private void Start()
	{
        mainCamera = Camera.main;

        defenderParent = GameObject.Find("Defenders");
        if (defenderParent == null)
        {
            defenderParent = new GameObject("Defenders");
        }

        starDisplay = FindObjectOfType<StarDisplay>();
	}

	private void OnMouseDown()
	{
        if (SelectableButton.selectedButton != null)
        {
            GameObject defenderPrefab = SelectableButton.selectedButton.GetDefender();
            int defenderCost = defenderPrefab.GetComponent<Defender>().starCost;

            if (starDisplay.UseStar(defenderCost) == Status.SUCCESS)
            {
                SpawnDefender(defenderPrefab);
            }
            else
            {
                Debug.Log("Insufficient stars");
            }
        }
	}

    private void SpawnDefender(GameObject defenderPrefab)
    {
        Vector2 position = SnapToGrid(CalculateMousePositionInWorldUnit());
        GameObject defender = Instantiate(defenderPrefab, position, Quaternion.identity);
        defender.transform.SetParent(defenderParent.transform);
    }

    private Vector2 CalculateMousePositionInWorldUnit()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        int newX = Mathf.RoundToInt(rawWorldPosition.x);
        int newY = Mathf.RoundToInt(rawWorldPosition.y);
        return new Vector2(newX, newY);
    }
}
