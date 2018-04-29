using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text textComponent;
    private int stars = 20;

	private void Start()
	{
        textComponent = GetComponent<Text>();
        UpdateStarDisplay();
	}

	public void AddStar(int amount)
    {
        stars += amount;
        UpdateStarDisplay();
    }

    public Status UseStar(int amount)
    {
        if (stars >= amount) 
        {
			stars -= amount;
			UpdateStarDisplay();
			return Status.SUCCESS;
        }

		return Status.FAILURE;
    }

    void UpdateStarDisplay()
    {
        textComponent.text = stars.ToString();
    }
}
