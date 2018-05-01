using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableButton : MonoBehaviour {

    public static SelectableButton selectedButton = null;
    public GameObject defenderPrefab;

    private SpriteRenderer spriteRenderer;

    private Text costTextComponent;
    private int starCost;

	private void Start()
	{
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black;

        SetCostDisplay();

        if (defenderPrefab == null)
        {
            Debug.LogWarning(name + " does not have a defenderPrefab attached");
        }
    }

    private void SetCostDisplay()
    {
        costTextComponent = GetComponentInChildren<Text>();
        if (costTextComponent == null)
        {
            Debug.LogWarning(name + " cannot find child's Text Component");
        }
        else
        {
            Defender defender = defenderPrefab.GetComponent<Defender>();
            if (defender == null)
            {
                Debug.LogWarning(name + " cannot find Defender script in defenderPrefab");
            }
            else
            {
                starCost = defender.starCost;
                UpdateCostDisplay();
            }
        }
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

    void UpdateCostDisplay()
    {
        costTextComponent.text = starCost.ToString();
    }

}
