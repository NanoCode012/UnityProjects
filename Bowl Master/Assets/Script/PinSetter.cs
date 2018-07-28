using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text standingPinText;

    private Pin[] pins;

    // Use this for initialization
    void Start () {
        pins = FindObjectsOfType<Pin>();
	}

    void SetTextDisplay(int count)
    {
        standingPinText.text = count.ToString();
    }

    private void Update()
    {
        SetTextDisplay(CountStanding());
    }

    int CountStanding()
    {
        int pinStanding = 0;
        foreach (var pin in pins)
        {
            if (pin)
            {
                if (pin.IsStanding()) pinStanding++;
            }
        }
        return pinStanding;
    }
}
